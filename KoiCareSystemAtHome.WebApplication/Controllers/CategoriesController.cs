using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly YourDbContext _context;

    public CategoriesController(YourDbContext context)
    {
        _context = context;
    }

    // Lấy tất cả danh mục
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        return await _context.Categories.Include(c => c.Articles).ToListAsync();
    }

    // Lấy danh mục theo ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        var category = await _context.Categories.Include(c => c.Articles).FirstOrDefaultAsync(c => c.CategoryId == id);
        if (category == null)
        {
            return NotFound("Danh mục không tồn tại.");
        }
        return category;
    }

    // Tạo mới danh mục
    [HttpPost]
    public async Task<ActionResult<Category>> CreateCategory(Category category)
    {
        if (category == null || string.IsNullOrEmpty(category.Name))
        {
            return BadRequest("Tên danh mục không được để trống.");
        }
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, category);
    }

    // Cập nhật danh mục
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, Category category)
    {
        if (id != category.CategoryId)
        {
            return BadRequest("ID danh mục không khớp.");
        }

        if (string.IsNullOrEmpty(category.Name))
        {
            return BadRequest("Tên danh mục không được để trống.");
        }

        _context.Entry(category).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoryExists(id))
            {
                return NotFound("Danh mục không tồn tại.");
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // Xóa danh mục
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound("Danh mục không tồn tại.");
        }
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // Kiểm tra xem danh mục có tồn tại không
    private bool CategoryExists(int id)
    {
        return _context.Categories.Any(e => e.CategoryId == id);
    }
}
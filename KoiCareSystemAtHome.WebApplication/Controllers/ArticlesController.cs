using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController : ControllerBase
{
    private readonly YourDbContext _context;

    public ArticlesController(YourDbContext context)
    {
        _context = context;
    }

    // Lấy tất cả bài viết
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
    {
        return await _context.Articles.Include(a => a.Category).Include(a => a.Comments).ToListAsync();
    }

    // Lấy bài viết theo ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> GetArticle(int id)
    {
        var article = await _context.Articles.Include(a => a.Category).Include(a => a.Comments).FirstOrDefaultAsync(a => a.ArticleId == id);
        if (article == null)
        {
            return NotFound();
        }
        return article;
    }

    // Tạo mới bài viết
    [HttpPost]
    public async Task<ActionResult<Article>> CreateArticle(Article article)
    {
        if (article == null || string.IsNullOrEmpty(article.Title) || string.IsNullOrEmpty(article.Content))
        {
            return BadRequest("Tiêu đề và nội dung bài viết không được để trống.");
        }
        _context.Articles.Add(article);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetArticle), new { id = article.ArticleId }, article);
    }

    // Cập nhật bài viết
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArticle(int id, Article article)
    {
        if (id != article.ArticleId)
        {
            return BadRequest("ID bài viết không khớp.");
        }

        if (string.IsNullOrEmpty(article.Title) || string.IsNullOrEmpty(article.Content))
        {
            return BadRequest("Tiêu đề và nội dung bài viết không được để trống.");
        }

        _context.Entry(article).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ArticleExists(id))
            {
                return NotFound("Bài viết không tồn tại.");
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // Xóa bài viết
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticle(int id)
    {
        var article = await _context.Articles.FindAsync(id);
        if (article == null)
        {
            return NotFound("Bài viết không tồn tại.");
        }
        _context.Articles.Remove(article);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // Kiểm tra xem bài viết có tồn tại không
    private bool ArticleExists(int id)
    {
        return _context.Articles.Any(e => e.ArticleId == id);
    }
}

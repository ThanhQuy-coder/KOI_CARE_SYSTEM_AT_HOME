using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly YourDbContext _context;

    public CommentsController(YourDbContext context)
    {
        _context = context;
    }

    // Lấy tất cả bình luận
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
    {
        return await _context.Comments.Include(c => c.Article).ToListAsync();
    }

    // Lấy bình luận theo ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> GetComment(int id)
    {
        var comment = await _context.Comments.Include(c => c.Article).FirstOrDefaultAsync(c => c.CommentId == id);
        if (comment == null)
        {
            return NotFound("Bình luận không tồn tại.");
        }
        return comment;
    }

    // Tạo mới bình luận
    [HttpPost]
    public async Task<ActionResult<Comment>> CreateComment(Comment comment)
    {
        if (comment == null || string.IsNullOrEmpty(comment.Content))
        {
            return BadRequest("Nội dung bình luận không được để trống.");
        }
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetComment), new { id = comment.CommentId }, comment);
    }

    // Cập nhật bình luận
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateComment(int id, Comment comment)
    {
        if (id != comment.CommentId)
        {
            return BadRequest("ID bình luận không khớp.");
        }

        if (string.IsNullOrEmpty(comment.Content))
        {
            return BadRequest("Nội dung bình luận không được để trống.");
        }

        _context.Entry(comment).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CommentExists(id))
            {
                return NotFound("Bình luận không tồn tại.");
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // Xóa bình luận
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null)
        {
            return NotFound("Bình luận không tồn tại.");
        }
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // Kiểm tra xem bình luận có tồn tại không
    private bool CommentExists(int id)
    {
        return _context.Comments.Any(e => e.CommentId == id);
    }
}
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class EditCommentModel : PageModel
{
    private readonly ICommentsService _commentsService;

    [BindProperty]
    public Comment Comment { get; set; }

    public EditCommentModel(ICommentsService commentsService)
    {
        _commentsService = commentsService;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Comment = await _commentsService.GetCommentByIdAsync(id);
        if (Comment == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _commentsService.UpdateCommentAsync(Comment);
        return RedirectToPage("Index");
    }
}

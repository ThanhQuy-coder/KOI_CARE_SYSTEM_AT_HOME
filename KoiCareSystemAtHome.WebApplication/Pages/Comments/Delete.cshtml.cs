using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystemAtHome.WebApplication.Pages.Comments
{
    public class DeleteCommentModel : PageModel
    {
        private readonly ICommentsService _commentsService;

        [BindProperty]
        public Comment Comment { get; set; }

        public DeleteCommentModel(ICommentsService commentsService)
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _commentsService.DeleteCommentAsync(id);
            return RedirectToPage("Index");
        }
    }
}

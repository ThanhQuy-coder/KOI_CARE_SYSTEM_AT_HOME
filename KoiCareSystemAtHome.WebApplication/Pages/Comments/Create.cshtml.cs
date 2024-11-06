using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystemAtHome.WebApplication.Pages.Comments
{
    public class CreateCommentModel : PageModel
    {
        private readonly ICommentsService _commentsService;

        [BindProperty]
        public Comment Comment { get; set; }

        public CreateCommentModel(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _commentsService.AddCommentAsync(Comment);
            return RedirectToPage("Index");
        }
    }
}

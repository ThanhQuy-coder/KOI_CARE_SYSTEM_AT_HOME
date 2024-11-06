using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Services.Services;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.WebApplication.Pages.Articles
{
    public class DeleteModel : PageModel
    {
        private readonly IArticlesService _articlesService;

        public DeleteModel(IArticlesService articlesService)
        {
            _articlesService = articlesService;
        }

        [BindProperty]
        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Article = await _articlesService.GetArticleByIdAsync(id);

            if (Article == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _articlesService.DeleteArticleAsync(id);
            return RedirectToPage("./Index");
        }
    }
}

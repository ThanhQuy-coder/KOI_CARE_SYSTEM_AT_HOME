using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Services.Services;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.WebApplication.Pages.Articles
{
    public class EditModel : PageModel
    {
        private readonly IArticlesService _articlesService;

        public EditModel(IArticlesService articlesService)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _articlesService.UpdateArticleAsync(Article);
            return RedirectToPage("./Index");
        }
    }
}

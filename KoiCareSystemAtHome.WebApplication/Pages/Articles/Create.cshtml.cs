using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Services.Services;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.WebApplication.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly IArticlesService _articlesService;

        public CreateModel(IArticlesService articlesService)
        {
            _articlesService = articlesService;
        }

        [BindProperty]
        public Article Article { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _articlesService.AddArticleAsync(Article);
            return RedirectToPage("./Index");
        }
    }
}

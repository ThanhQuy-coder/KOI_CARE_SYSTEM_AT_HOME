using KoiCareSystemAtHome.Services.Interfaces;
using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.WebApplication.Pages.NewsPage
{
    public class CreateModel : PageModel
    {
        private readonly INewsService _newsService;

        public CreateModel(INewsService newsService)
        {
            _newsService = newsService;
        }

        [BindProperty]
        public News News { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Task.FromResult<IActionResult>(Page());
            }

            _newsService.AddNews(News);
            return Task.FromResult<IActionResult>(RedirectToPage("./Index"));
        }
    }
}
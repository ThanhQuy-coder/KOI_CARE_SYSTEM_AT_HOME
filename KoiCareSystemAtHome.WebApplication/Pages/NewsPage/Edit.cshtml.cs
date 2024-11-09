using KoiCareSystemAtHome.Services.Interfaces;
using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.WebApplication.Pages.NewsPage
{
    public class EditModel : PageModel
    {
        private readonly INewsService _newsService;

        public EditModel(INewsService newsService)
        {
            _newsService = newsService;
        }

        [BindProperty]
        public News News { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            News = (News)await _newsService.GetNewsByIdAsync(id);

            if (News == null)
            {
                return NotFound();
            }

            return Page();
        }

        public Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Task.FromResult<IActionResult>(Page());
            }

             _newsService.UpdateNews(News);

            return Task.FromResult<IActionResult>(RedirectToPage("./Index"));
        }
    }
}
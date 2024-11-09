using KoiCareSystemAtHome.Services.Interfaces;
using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.WebApplication.Pages.NewsPage
{
    public class DeleteModel : PageModel
    {
        private readonly INewsService _newsService;

        public DeleteModel(INewsService newsService)
        {
            _newsService = newsService;
        }

        [BindProperty]
        public News News { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            News = await _newsService.GetNewsByIdAsync(id);

            if (News == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var success =  _newsService.DeleteNews(id);

            if (!success)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}

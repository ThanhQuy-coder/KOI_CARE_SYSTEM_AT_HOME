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
            News = _newsService.GetNewsById(id);

            if (News == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var news = _newsService.GetNewsById(id);

            if (news != null)
            {
                _newsService.DeleteNews(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
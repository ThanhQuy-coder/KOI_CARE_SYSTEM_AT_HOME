using KoiCareSystemAtHome.Services.Interfaces;
using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.WebApplication.Pages.NewsPage
{
    public class DetailsModel : PageModel
    {
        private readonly INewsService _newsService;

        public DetailsModel(INewsService newsService)
        {
            _newsService = newsService;
        }

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
    }
}
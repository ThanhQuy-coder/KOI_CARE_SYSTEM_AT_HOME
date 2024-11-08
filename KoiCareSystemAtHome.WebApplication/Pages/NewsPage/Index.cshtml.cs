using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.WebApplication.Pages.NewsPage
{
    public class IndexModel : PageModel
    {
        private readonly INewsService _newsService;

        public IndexModel(INewsService newsService)
        {
            _newsService = newsService;
        }

        public IList<News> News { get; set; } = default!;

        public async Task OnGet()
        {
            News = (IList<News>)_newsService.GetAllNews();
        }
    }
}


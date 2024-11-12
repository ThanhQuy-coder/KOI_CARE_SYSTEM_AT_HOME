using KoiCareSystemAtHome.Services.Interfaces;
using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KoiCareSystemAtHome.WebApplication.Pages.NewsPage
{
    public class IndexModel : PageModel
    {
        private readonly INewsService _newsService;

        public IndexModel(INewsService newsService)
        {
            _newsService = newsService;
        }

        public List<News> News { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task<IActionResult> OnGetAsync(string searchTerm, string author, DateTime? publishDate)
        {
            News = await _newsService.GetAllNewsAsync();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                News = News.Where(n => n.Title.Contains(searchTerm) || n.Content.Contains(searchTerm)).ToList();
            }

            if (!string.IsNullOrEmpty(author))
            {
                News = News.Where(n => n.Author.Contains(author)).ToList();
            }

            if (publishDate.HasValue)
            {
                News = News.Where(n => n.PublishDate.Date == publishDate.Value.Date).ToList();
            }

            return Page();
        }

    }
}






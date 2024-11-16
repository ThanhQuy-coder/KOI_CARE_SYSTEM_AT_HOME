using KoiCareSystemAtHome.Services.Interfaces;
using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            var newsList = await _newsService.GetAllNewsAsync();

            // Đảm bảo rằng danh sách không bị null
            if (newsList != null)
            {
                // Loại bỏ các mục null trong danh sách nếu có
                News = newsList.Where(n => n != null).ToList();

                // Thực hiện tìm kiếm nếu có từ khóa
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    News = News.Where(n =>
                        (n.Title != null && n.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                        (n.Content != null && n.Content.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    ).ToList();
                }

                if (!string.IsNullOrEmpty(author))
                {
                    News = News.Where(n => n.Author != null && n.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                if (publishDate.HasValue)
                {
                    News = News.Where(n => n.PublishDate.Date == publishDate.Value.Date).ToList();
                }
            }
            else
            {
                // Nếu danh sách bị null, khởi tạo một danh sách trống
                News = new List<News>();
            }

            return Page();
        }
    }
}





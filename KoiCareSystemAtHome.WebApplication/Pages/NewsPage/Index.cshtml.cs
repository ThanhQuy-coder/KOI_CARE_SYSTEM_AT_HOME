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

        public async Task<IActionResult> OnGetAsync()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                // Tìm kiếm các bài viết có chứa từ khóa trong Title hoặc Content
                News = await _newsService.SearchNewsAsync(SearchTerm);
            }
            else
            {
                // Nếu không có từ khóa tìm kiếm, hiển thị tất cả bài viết
                News = await _newsService.GetAllNewsAsync();
            }

            return Page();
        }
    }
}






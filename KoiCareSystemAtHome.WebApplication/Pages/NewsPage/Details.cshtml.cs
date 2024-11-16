using KoiCareSystemAtHome.Services.Interfaces;
using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // Thêm thuộc tính để lưu các tin khác (Other News)
        public List<News> OtherNews { get; set; } = new List<News>();

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            News = await _newsService.GetNewsByIdAsync(id);

            if (News == null)
            {
                return NotFound();
            }

            // Lấy danh sách các bài viết khác (Other News)
            OtherNews = (await _newsService.GetAllNewsAsync())
                        .Where(n => n.PostId != id)  // Lọc ra các bài viết khác với bài viết hiện tại
                        .Take(5)                    // Giới hạn số lượng bài viết liên quan (5 bài)
                        .ToList();

            return Page();
        }
    }
}


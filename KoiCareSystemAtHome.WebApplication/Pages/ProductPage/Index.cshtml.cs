using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.ProductPage
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _service;

        public IndexModel(IProductService service)
        {
            _service = service;
        }

        public IList<Product> Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            // Lấy UserId từ Session
            var userId = HttpContext.Session.GetString("UserId");

            // Kiểm tra nếu không có UserId trong Session (nghĩa là chưa đăng nhập)
            if (string.IsNullOrEmpty(userId))
            {
                // Chuyển hướng người dùng về trang đăng nhập
                return RedirectToPage("/LoginPage/Index");
            }

            // Nếu có UserId, tiếp tục xử lý
            // Truyền UserId vào ViewData để có thể sử dụng trong Razor Page nếu cần
            ViewData["UserId"] = userId;

            // Lấy tất cả các hồ từ dịch vụ
            Product = await _service.GetAllProducts();

            // Trả về trang Razor (Page) sau khi đã lấy dữ liệu
            return Page();
        }
    }
}

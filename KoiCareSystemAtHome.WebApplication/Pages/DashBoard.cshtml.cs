using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystemAtHome.WebApplication.Pages
{
    public class DashBoardModel : PageModel
    {
        private readonly IKoiFishService _koifishService;

        public DashBoardModel(IKoiFishService koifishService)
        {
            _koifishService = koifishService;
        }

        public List<KoiFish> KoiData { get; set; }

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
            return Page();
        }
    }
}


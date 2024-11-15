using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.WebApplication.Pages.LoginPage
{
    public class logoutModel : PageModel
    {
        // Phương thức này sẽ được gọi khi người dùng nhấn nút "Đăng xuất"
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            
            HttpContext.Session.Clear();

            return RedirectToPage("/Index");
        }
    }
}

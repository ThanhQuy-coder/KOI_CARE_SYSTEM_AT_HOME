using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;
using KoiCareSystemAtHome.Services.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace KoiCareSystemAtHome.WebApplication.Pages.LoginPage
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IUserProfileService _userService;

        public LoginModel(IUserProfileService userService, IAccountService accountService)
        {
            _accountService = accountService;
            _userService = userService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;
        public new UserProfile User { get; set; } = new UserProfile { UserId = Guid.Empty, FullName = "#" };

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Account.Username");

            //Kiểm tra
            if (!ModelState.IsValid)
            {
                // In ra các lỗi Validation để biết trường nào đang bị thiếu
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            var authenticatedAccount = await _accountService.checkAccount(Account.Email, Account.PasswordHash);

            if (authenticatedAccount == null)
            {
                ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không chính xác!");
                return Page();
            }

            var userProfile = await _userService.CheckUser(authenticatedAccount.AccountId);

            if (!userProfile.IsExisted)
            {
                ModelState.AddModelError(string.Empty, "Không tìm thấy hồ sơ người dùng.");
                return Page();
            }

            if (userProfile.User == null)
            {
                throw new Exception("Thông tin người dùng không hợp lệ.");
            }

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userProfile.User.UserId.ToString()),
                new Claim(ClaimTypes.Email, authenticatedAccount.Email),
                new Claim(ClaimTypes.Role, userProfile.User.Role),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties { IsPersistent = true };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            HttpContext.Session.SetString("UserId", userProfile.User.UserId.ToString());

            return RedirectToPage("/DashBoard");
        }
    }
}

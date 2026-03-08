using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;
using KoiCareSystemAtHome.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using System.Reflection.Metadata;

namespace KoiCareSystemAtHome.WebApplication.Pages.LoginPage
{
    public class RegisterModel : PageModel
    {
        private readonly IUserProfileService _userService;
        private readonly IAccountService _accountService;

        public RegisterModel(IUserProfileService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public new UserProfile User { get; set; } = default!;

        [BindProperty]
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("User.Role");
            ModelState.Remove("User.Account");

            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            try
            {
                var createdAccount = await _accountService.AddAccount(Account);

                if (createdAccount == null)
                {
                    ModelState.AddModelError(string.Empty, "Không thể tạo tài khoản. Vui lòng thử lại.");
                    return Page();
                }

                User.AccountId = createdAccount.AccountId;
                User.BirthDate = null;
                User.Gender = "Other";
                User.Role = "User";

                var isUserCreated = await _userService.AddUser(User);

                if (!isUserCreated)
                {
                    ModelState.AddModelError(string.Empty, "Tài khoản đã tạo nhưng không thể khởi tạo thông tin người dùng.");
                    return Page();
                }

                return RedirectToPage("/LoginPage/Index");
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                ModelState.AddModelError(string.Empty, "Lỗi hệ thống: " + innerMessage);
                return Page();
            }
        }
    }
}

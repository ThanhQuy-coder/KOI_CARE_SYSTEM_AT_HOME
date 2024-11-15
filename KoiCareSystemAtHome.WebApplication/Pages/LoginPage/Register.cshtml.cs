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
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public RegisterModel(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;
        [BindProperty]
        public Account Account { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        // Nhận AccountID từ query string khi chuyển hướng từ trang tạo Account

        public async Task<IActionResult> OnPostAsync()
        {
            // Tạo Account

            var resultAccount = _accountService.AddAccount(Account);
            if (!resultAccount)
            {
                
                ModelState.AddModelError(string.Empty, "Error");
                return Page();
            }

            User.AccountId = Account.AccountId;
            User.BirthDate = DateTime.Now;
            User.Gender = "null";
            User.Role = "null";

            if (User.AccountId == Guid.Empty)
            {
                ModelState.AddModelError(string.Empty, "AccountId is required.");
                return Page();
            }

            // Tạo User
            var resultUser = _userService.AddUser(User);
            if (!resultUser)
            {
                ModelState.AddModelError(string.Empty, "Error");
                return Page();
            }

            return RedirectToPage("/LoginPage/Index");
        }
    }
}

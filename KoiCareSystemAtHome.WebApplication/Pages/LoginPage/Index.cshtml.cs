using KoiCareSystemAtHome.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Services.Services;

namespace KoiCareSystemAtHome.WebApplication.Pages.LoginPage
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountService;

        public LoginModel(IUserService userService, IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("Hello");
            //Kiểm tra
            if (!_accountService.checkAccount(Account.Email, Account.PassWordHash))
            {
                return Page();
            }
            HttpContext.Session.SetString("AccountId", Account.AccountId.ToString());
            return RedirectToPage("/Index");
        }
    }
}

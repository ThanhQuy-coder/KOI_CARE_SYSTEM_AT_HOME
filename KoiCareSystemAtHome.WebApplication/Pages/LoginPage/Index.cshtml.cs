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
        private readonly IUserService _userService;

        public LoginModel(IUserService userService, IAccountService accountService)
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
        public User User { get; set; } = new User { UserId = Guid.Empty, FullName = "#" };

        public async Task<IActionResult> OnPostAsync()
        {
            //Kiểm tra
            Guid accountIdTemp = Account.AccountId;
            Guid userAccountIdTemp = (Guid)User.UserId;
            
            if (!_accountService.checkAccount(Account.Email, Account.PassWordHash, ref accountIdTemp))
            {
                return Page();
            }
            Account.AccountId = accountIdTemp;
            //Kiểm tra user
            _userService.CheckUser(Account.AccountId, ref userAccountIdTemp);
            User.UserId = userAccountIdTemp;
            HttpContext.Session.SetString("UserId", User.UserId.ToString());
            return RedirectToPage("/Index", new {User = User.UserId});
        }
    }
}

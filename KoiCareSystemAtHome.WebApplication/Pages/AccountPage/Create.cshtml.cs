using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace KoiCareSystemAtHome.WebApplication.Pages.AccountPage
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _accountService;

        public CreateModel(IAccountService accountService)
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
            if (!ModelState.IsValid || Account == null)
            {
                return Page();
            }

            var isSuccess = await _accountService.AddAccount(Account);
            
            if (isSuccess != null)
            {
                ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi khi tạo tài khoản. Vui lòng thử lại.");
                return Page();
            }

            return RedirectToPage("/UserPage/Create", new { AccountId = Account.AccountId });
        }
    }
}

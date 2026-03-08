using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;
using KoiCareSystemAtHome.Services.Services;

namespace KoiCareSystemAtHome.WebApplication.Pages.AccountPage
{
    public class EditModel : PageModel
    {
        private readonly IAccountService _accountService;

        public EditModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _accountService.GetAccountById(id.Value);

            if (account == null)
            {
                return NotFound();
            }
            Account = account;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var result = await _accountService.UpdateAccount(Account);

                if (!result)
                {
                    ModelState.AddModelError(string.Empty, "Không thể cập nhật tài khoản. Vui lòng kiểm tra lại.");
                    return Page();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError(string.Empty, "Dữ liệu đã bị thay đổi bởi một người dùng khác. Hãy tải lại trang.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

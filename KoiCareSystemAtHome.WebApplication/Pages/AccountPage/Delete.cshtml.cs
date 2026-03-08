using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.AccountPage
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountService _accountService;
        public DeleteModel(IAccountService accountService)
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

            var account = await _accountService.GetAccountById(id);

            if (account == null)
            {
                return NotFound();
            }
            else
            {
                Account = account;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Check Account exist
            var account = await _accountService.GetAccountById(id.Value);
            if (account == null)
            {
                return NotFound();
            }

            var result = await _accountService.DelAccount(id.Value);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Không thể xóa tài khoản này. Có thể do dữ liệu liên quan vẫn tồn tại.");
                Account = account;
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

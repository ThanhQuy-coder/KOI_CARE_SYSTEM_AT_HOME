using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.AccountPage
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _accountService;

        public CreateModel(IAccountService context)
        {
            _accountService = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = _accountService.AddAccount(Account);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error");
                return Page();
            }

            return RedirectToPage("/UserPage/Create");
        }
    }
}

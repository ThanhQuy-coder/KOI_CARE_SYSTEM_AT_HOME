using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;
using KoiCareSystemAtHome.Services.Services;
using Microsoft.Identity.Client;


namespace KoiCareSystemAtHome.WebApplication.Pages.UserPage
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;

        public CreateModel(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet(Guid accountId)
        {
            // Gán PondId vào KoiFish
            User = new User { AccountId = accountId };
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        // Nhận AccountID từ query string khi chuyển hướng từ trang tạo Account
        
        public async Task<IActionResult> OnPostAsync(Guid accountId)
        {
            if (User.AccountId == Guid.Empty)
            {
                ModelState.AddModelError(string.Empty, "Bạn phải có tài khoản trước!.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = _userService.AddUser(User);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.UserPage
{
    public class IndexModel : PageModel
    {
        private readonly IUserProfileService _userService;

        public IndexModel(IUserProfileService userService)
        {
            _userService = userService;
        }

        public IList<UserProfile> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = await _userService.GetAllUser();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.FeedingSchedulePages
{
    public class CreateModel : PageModel
    {
        private readonly IFeedingScheduleService _service;

        public CreateModel(IFeedingScheduleService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FeedingSchedule FeedingSchedule { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _service.AddFeedingSchedule(FeedingSchedule);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error adding WaterParameter.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
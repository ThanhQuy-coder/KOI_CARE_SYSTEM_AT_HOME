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

        [BindProperty]
        public FeedingSchedule FeedingSchedule { get; set; } = default!;

        // Nhận PondId từ query string trong URL
        public IActionResult OnGet(Guid fishId)
        {
            // Gán PondId vào KoiFish
            FeedingSchedule = new FeedingSchedule { FishId = fishId };
            return Page();
        }
        public IActionResult OnPost()
        {
            if (FeedingSchedule.FishId == Guid.Empty)
            {
                ModelState.AddModelError(string.Empty, "FishId is required.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _service.AddFeedingSchedule(FeedingSchedule);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error adding.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
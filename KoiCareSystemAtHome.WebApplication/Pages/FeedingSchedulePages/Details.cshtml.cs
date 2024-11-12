using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.FeedingSchedulePages
{
    public class DetailsModel : PageModel
    {
        private readonly IFeedingScheduleService _service;

        public DetailsModel(IFeedingScheduleService service)
        {
            _service = service;
        }

        public FeedingSchedule FeedingSchedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedingschedule = await _service.GetFeedingScheduleById((Guid)id);
            if (feedingschedule == null)
            {
                return NotFound();
            }
            else
            {
                FeedingSchedule = feedingschedule;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedingSchedule = await _service.GetFeedingScheduleById((Guid)id);

            return RedirectToPage("./Index");
        }
    }
}

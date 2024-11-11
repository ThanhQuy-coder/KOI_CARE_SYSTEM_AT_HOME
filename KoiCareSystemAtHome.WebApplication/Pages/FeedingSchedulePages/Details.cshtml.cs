using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.WebApplication.Pages.FeedingSchedulePages
{
    public class DetailsModel : PageModel
    {
        private readonly KoiCareSystemAtHome.Repositories.Entities.KoiCareSystemAtHomeContext _context;

        public DetailsModel(KoiCareSystemAtHome.Repositories.Entities.KoiCareSystemAtHomeContext context)
        {
            _context = context;
        }

        public FeedingSchedule FeedingSchedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedingschedule = await _context.FeedingSchedules.FirstOrDefaultAsync(m => m.FeedingScheduleId == id);
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
    }
}

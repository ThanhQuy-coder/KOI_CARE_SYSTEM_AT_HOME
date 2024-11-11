using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.WaterParameterPages
{
    public class DeleteModel : PageModel
    {
        private readonly IFeedingScheduleService _service;

        public DeleteModel(IFeedingScheduleService service)
        {
            _service = service;
        }

        [BindProperty]
        public FeedingSchedule WaterParameter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)

            {
                return NotFound();
            }

            var feedingSchedule = await _service.GetFeedingScheduleById((int)id);

            if (feedingSchedule == null)
            {
                return NotFound();
            }
            else
            {
                FeedingSchedule = feedingSchedule;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _service.DelFeedingSchedule((int)id);
            return RedirectToPage("./Index");
        }
    }
}
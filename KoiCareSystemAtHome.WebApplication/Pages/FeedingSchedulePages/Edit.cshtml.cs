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

namespace KoiCareSystemAtHome.WebApplication.Pages.FeedingSchedulePages
{
    public class EditModel : PageModel
    {
        private readonly IFeedingScheduleService _service;

        public EditModel(IFeedingScheduleService service)
        {
            _service = service;
        }

        [BindProperty]
        public FeedingSchedule FeedingSchedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool result = await Task.Run(() => _service.UpdateFeedingSchedule(FeedingSchedule));

            return RedirectToPage("./Index");
        }

        private async Task<bool> FeedingScheduleExists(Guid id)
        {
            var feedingSchedule = await _service.GetFeedingScheduleById(id);
            return feedingSchedule != null;
        }
    }
}

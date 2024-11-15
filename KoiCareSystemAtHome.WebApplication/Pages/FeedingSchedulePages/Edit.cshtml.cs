using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;
using System;
using System.Threading.Tasks;

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

        // Phương thức để lấy thông tin lịch cho ăn hiện có theo `FeedingScheduleId`
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var feedingSchedule = await _service.GetFeedingScheduleById(id);
            if (feedingSchedule == null)
            {
                return NotFound();
            }
            FeedingSchedule = feedingSchedule;
            return Page();
        }

        // Phương thức để lưu thay đổi
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingFeedingSchedule = await _service.GetFeedingScheduleById(FeedingSchedule.FeedingScheduleId);
            if (existingFeedingSchedule == null)
            {
                return NotFound();
            }

            // Cập nhật các trường cần thiết
            existingFeedingSchedule.FoodType = FeedingSchedule.FoodType;
            existingFeedingSchedule.FeedingTime = FeedingSchedule.FeedingTime;
            existingFeedingSchedule.RequiredFoodAmount = FeedingSchedule.RequiredFoodAmount;

            var result = _service.UpdateFeedingSchedule(existingFeedingSchedule);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error updating Feeding Schedule.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

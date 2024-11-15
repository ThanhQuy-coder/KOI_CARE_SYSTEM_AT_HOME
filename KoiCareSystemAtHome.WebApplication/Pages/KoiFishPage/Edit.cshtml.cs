using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.WebApplication.Pages.KoiFishPage
{
    public class EditModel : PageModel
    {
        private readonly IKoiFishService _service;

        public EditModel(IKoiFishService service)
        {
            _service = service;
        }

        [BindProperty]
        public KoiFish KoiFish { get; set; } = default!;

        // Phương thức để lấy thông tin cá Koi hiện có theo `FishId`
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var koiFish = await _service.GetKoiFishById(id);
            if (koiFish == null)
            {
                return NotFound();
            }
            KoiFish = koiFish;
            return Page();
        }

        // Phương thức để lưu thay đổi
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingKoiFish = await _service.GetKoiFishById(KoiFish.FishId);
            if (existingKoiFish == null)
            {
                return NotFound();
            }

            // Cập nhật các trường cần thiết
            existingKoiFish.NameFish = KoiFish.NameFish;
            existingKoiFish.BodyShape = KoiFish.BodyShape;
            existingKoiFish.AgeFish = KoiFish.AgeFish;
            existingKoiFish.Size = KoiFish.Size;
            existingKoiFish.WeightFish = KoiFish.WeightFish;
            existingKoiFish.Gender = KoiFish.Gender;
            existingKoiFish.Breed = KoiFish.Breed;
            existingKoiFish.Origin = KoiFish.Origin;
            existingKoiFish.Price = KoiFish.Price;
            existingKoiFish.FishLocation = KoiFish.FishLocation;

            // Cập nhật ảnh (nếu có)
            if (!string.IsNullOrEmpty(KoiFish.ImageFish))
            {
                existingKoiFish.ImageFish = KoiFish.ImageFish;
            }

            var result = _service.UpdateKoiFish(existingKoiFish);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error updating Koi Fish.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

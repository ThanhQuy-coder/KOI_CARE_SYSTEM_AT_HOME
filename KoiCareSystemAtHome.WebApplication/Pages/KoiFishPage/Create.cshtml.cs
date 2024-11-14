using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.KoiFishPage
{
    public class CreateModel : PageModel
    {
        private readonly IKoiFishService _service;

        public CreateModel(IKoiFishService service)
        {
            _service = service;
        }
        [BindProperty]
        public IFormFile? ImageFile { get; set; } // Nhận file ảnh

        [BindProperty]
        public KoiFish KoiFish { get; set; } = default!;

        // Nhận PondId từ query string trong URL
        public IActionResult OnGet(Guid pondId)
        {
            // Gán PondId vào KoiFish
            KoiFish = new KoiFish { PondId = pondId };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (KoiFish.PondId == Guid.Empty)
            {
                ModelState.AddModelError(string.Empty, "PondId is required.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ImageFile != null)
            {
                // Lưu file ảnh vào thư mục "wwwroot/uploads"
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine("wwwroot/images", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                // Lưu đường dẫn ảnh vào `KoiFish`
                KoiFish.ImageFish = fileName;
            }

            var result = _service.AddKoiFish(KoiFish);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error adding Koi Fish.");
                return Page();
            }

            return RedirectToPage("./Index");
        }



    }
}

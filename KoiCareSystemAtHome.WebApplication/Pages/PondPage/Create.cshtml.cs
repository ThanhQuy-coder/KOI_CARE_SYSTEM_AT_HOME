using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.PondPage

{
    public class CreateModel : PageModel
    {
        private readonly IPondService _service;

        public CreateModel(IPondService service)
        {
            _service = service;
        }
        [BindProperty]
        public IFormFile? ImageFile { get; set; } // Nhận file ảnh

        [BindProperty]
        public Pond Pond { get; set; } = default!;

        // Nhận UserId từ query string trong URL
        public IActionResult OnGet(Guid userId)
        {
            // Gán UserId vào Pond
            Pond = new Pond { UserId = userId };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Pond.UserId == Guid.Empty)
            {
                ModelState.AddModelError(string.Empty, "Chỉ được tạo hồ từ trang User !.");
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
                Pond.ImagePond = fileName;
            }

            var result = _service.AddPond(Pond);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error adding Koi Fish.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
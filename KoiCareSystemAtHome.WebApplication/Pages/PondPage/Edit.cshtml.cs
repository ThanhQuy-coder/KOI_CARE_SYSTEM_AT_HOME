using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.WebApplication.Pages.PondPage
{
    public class EditModel : PageModel
    {
        private readonly IPondService _service;

        public EditModel(IPondService service)
        {
            _service = service;
        }

        [BindProperty]
        public IFormFile? ImageFile { get; set; } // Nhận file ảnh
        [BindProperty]
        public Pond Pond { get; set; } = default!;

        // Phương thức để lấy thông tin hồ hiện có theo `PondId`
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var pond = await _service.GetPondById(id);
            if (pond == null)
            {
                return NotFound();
            }
            Pond = pond;
            return Page();
        }

        // Phương thức để lưu thay đổi
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingPond = await _service.GetPondById(Pond.PondId);
            if (existingPond == null)
            {
                return NotFound();
            }

            // Cập nhật các trường cần thiết
            existingPond.NamePond = Pond.NamePond;
            existingPond.Depth = Pond.Depth;
            existingPond.Volume = Pond.Volume;
            existingPond.DrainCount = Pond.DrainCount;
            existingPond.PumpCapacity = Pond.PumpCapacity;

            // Xử lý ảnh mới (nếu có)
            if (ImageFile != null)
            {
                // Tạo tên file ảnh duy nhất
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                // Lưu ảnh vào thư mục wwwroot/images
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                // Cập nhật đường dẫn ảnh mới vào sản phẩm
                existingPond.ImagePond = fileName;
            }

            // Cập nhật hồ vào cơ sở dữ liệu
            var result = _service.UpdatePond(existingPond);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error updating Pond.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

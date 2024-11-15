using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.ProductPage
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _service;

        public CreateModel(IProductService service)
        {
            _service = service;
        }
        [BindProperty]
        public IFormFile? ImageFile { get; set; } // Nhận file ảnh

        [BindProperty]
        public Product Product { get; set; } = default!;

        public IActionResult OnGet(Guid userId)
        {
            // Gán UserId vào Pond
            Product = new Product { UserId = userId };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Product.UserId == Guid.Empty)
            {
                ModelState.AddModelError(string.Empty, "Chỉ được tạo sản phẩm từ trang User !.");
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
                Product.ImageProduct = fileName;
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _service.AddProduct(Product);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error adding.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

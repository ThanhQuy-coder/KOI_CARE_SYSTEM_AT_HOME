using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.WebApplication.Pages.ProductPage
{
    public class EditModel : PageModel
    {
        private readonly IProductService _service;

        public EditModel(IProductService service)
        {
            _service = service;
        }
        [BindProperty]
        public IFormFile? ImageFile { get; set; } // Nhận file ảnh
        [BindProperty]
        public Product Product { get; set; } = default!;

        // Phương thức để lấy thông tin sản phẩm hiện có theo `ProductId`
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var product = await _service.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
            return Page();
        }

        // Phương thức để lưu thay đổi
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingProduct = await _service.GetProductById(Product.ProductId);
            if (existingProduct == null)
            {
                return NotFound();
            }

            // Cập nhật các trường cần thiết
            existingProduct.ProductName = Product.ProductName;
            existingProduct.Price = Product.Price;
            existingProduct.ProductType = Product.ProductType;
            existingProduct.DatePlace = Product.DatePlace;
            existingProduct.Desciption = Product.Desciption;

            // Xử lý ảnh mới (nếu có)
            if (ImageFile != null)
            {
                // Lưu ảnh mới vào thư mục (ví dụ: wwwroot/images)
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                // Cập nhật tên ảnh vào sản phẩm
                existingProduct.ImageProduct = fileName;
            }

            // Cập nhật sản phẩm vào cơ sở dữ liệu
            var result = _service.UpdateProduct(existingProduct);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error updating product.");
                return Page();
            }

            return RedirectToPage("./Index");
        }

    }
}

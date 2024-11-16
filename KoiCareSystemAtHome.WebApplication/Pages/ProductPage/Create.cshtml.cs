using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            // Gán UserId vào Product
            Product = new Product { UserId = userId };
            Console.WriteLine($"OnGet called with userId: {userId}");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("OnPostAsync called");

            if (Product.UserId == Guid.Empty)
            {
                Console.WriteLine("UserId is empty");
                ModelState.AddModelError(string.Empty, "Chỉ được tạo sản phẩm từ trang User!");
                return Page();
            }

            // Kiểm tra ModelState trước khi xử lý ảnh
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model state is invalid");
                return Page();
            }

            // Xử lý tệp ảnh nếu có
            if (ImageFile != null && ImageFile.Length > 0)
            {
                try
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    var filePath = Path.Combine("wwwroot/images", fileName);
                    Console.WriteLine($"Saving image to {filePath}");

                    // Lưu tệp vào đường dẫn
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(fileStream);
                    }

                    // Lưu đường dẫn ảnh vào Product
                    Product.ImageProduct = fileName;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving image: {ex.Message}");
                    ModelState.AddModelError(string.Empty, "Lỗi khi lưu ảnh.");
                    return Page();
                }
            }

            try
            {
                var result = _service.AddProduct(Product);
                if (!result)
                {
                    Console.WriteLine("Error adding product to database");
                    ModelState.AddModelError(string.Empty, "Lỗi khi thêm sản phẩm.");
                    return Page();
                }

                Console.WriteLine("Product added successfully");
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OnPostAsync: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi tạo sản phẩm.");
                return Page();
            }
        }
    }
}

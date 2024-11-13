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
        public Product Product { get; set; } = default!;

        public IActionResult OnGet(Guid userId)
        {
            // Gán UserId vào Pond
            Product = new Product { UserId = userId };
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Product.UserId == Guid.Empty)
            {
                ModelState.AddModelError(string.Empty, "PondId is required.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _service.AddProduct(Product);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error adding Koi Fish.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

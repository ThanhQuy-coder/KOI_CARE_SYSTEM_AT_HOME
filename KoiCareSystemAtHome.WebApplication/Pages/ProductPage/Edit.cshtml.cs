using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

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
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _service.GetProductById((Guid)id);
            if (product == null)
            {
                return NotFound();
            }

            Product = product;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool result = _service.UpdateProduct(Product);

            if (!result)
            {
                if (!await ProductExists(Product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception("Lỗi cập nhật sản phẩm.");
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> ProductExists(Guid id)
        {
            var product = await _service.GetProductById(id);
            return product != null;
        }
    }
}

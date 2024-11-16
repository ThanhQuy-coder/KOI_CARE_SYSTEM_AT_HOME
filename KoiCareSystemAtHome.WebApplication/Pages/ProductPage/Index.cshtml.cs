using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.ProductPage
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _service;

        public IndexModel(IProductService service)
        {
            _service = service;
        }

        public List<Product> Product { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ProductType { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Product = await _service.GetAllProducts();

            // Tìm kiếm theo tên cá hoặc giá
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Product = Product.Where(p => p.ProductName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                                               p.Price.ToString().Contains(SearchTerm)).ToList();
            }

            // Tìm kiếm theo loại sản phẩm
            if (!string.IsNullOrEmpty(ProductType))
            {
                Product = Product.Where(p => p.ProductType.Contains(ProductType, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return Page();
        }
    }
}

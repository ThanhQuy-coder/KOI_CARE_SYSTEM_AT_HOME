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
    public class DetailsModel : PageModel
    {
        private readonly IProductService _service;

        public DetailsModel(IProductService service)
        {
            _service = service;
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
           
                int Id = 0;
                if (id == null)
                {
                    Id = 0;
                    return NotFound();
                }
                Id = (int)id;

                var product = await _service.GetProductById(Id);
                if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }

            return Page();
        }
    }
}

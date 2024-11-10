using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.ProductPage
{
    public class DeleteModel : PageModel
    {
        private readonly IProductService _service;

        public DeleteModel(IProductService service)
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
            else
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            {

                if (id == null)
                {

                    return NotFound();
                }

                bool result = _service.DeleteProduct((Guid)id);

                if (!result)
                {
                    return NotFound();
                }

                return RedirectToPage("./Index");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.SaltCalculationPages
{
    public class CreateModel : PageModel
    {
        private readonly ISaltCalculationService _service;

        public CreateModel(ISaltCalculationService service)
        {
            _service = service;
        }

        [BindProperty]
        public SaltCalculation SaltCalculation { get; set; } = default!;

        public IActionResult OnGet(Guid pondId)
        {
            // Gán PondId vào Thông số muối
            SaltCalculation = new SaltCalculation { PondId = pondId };
            return Page();
        }

 


        public async Task<IActionResult> OnPostAsync()
        {
            if (SaltCalculation.PondId == Guid.Empty)
            {
                ModelState.AddModelError(string.Empty, "PondId is required.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _service.AddSaltCalculation(SaltCalculation);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error adding.");
                return Page();
            }


            return RedirectToPage("./Index");
        }
    }
}

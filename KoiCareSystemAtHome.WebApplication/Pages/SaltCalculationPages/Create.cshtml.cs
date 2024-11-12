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

        public IActionResult OnGet()
        {
            //ViewData["PondId"] = new SelectList(_context.Ponds, "PondId", "NamePond");
            return Page();
        }

        [BindProperty]
        public SaltCalculation SaltCalculation { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _service.AddSaltCalculation(SaltCalculation);

            if(!result)
            {
                ModelState.AddModelError(string.Empty, "Error");
                return Page();
            }


            return RedirectToPage("./Index");
        }
    }
}

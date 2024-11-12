using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.SaltCalculationPages
{
    public class EditModel : PageModel
    {
        private readonly ISaltCalculationService _service;

        public EditModel(ISaltCalculationService service)
        {
            _service = service;
        }

        [BindProperty]
        public SaltCalculation SaltCalculation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saltcalculation = await _service.GetSaltCalculationById(id);
            if (saltcalculation == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool result = await Task.Run(() => _service.UpdateSaltCalculation(SaltCalculation));

            return RedirectToPage("./Index");
        }

        private async Task<bool> SaltCalculationExists(Guid id)
        {
            var saltCalculation = await _service.GetSaltCalculationById(id);
            return saltCalculation != null;
        }
    }
}

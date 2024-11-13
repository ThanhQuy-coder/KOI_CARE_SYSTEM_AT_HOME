using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.SaltCalculationPages
{
    public class DeleteModel : PageModel
    {
        private readonly ISaltCalculationService _service;

        public DeleteModel(ISaltCalculationService service)
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

            var saltCalculation = await _service.GetSaltCalculationById((Guid)id);

            if (saltCalculation == null)
            {
                return NotFound();
            }
            else
            {
                SaltCalculation = saltCalculation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            bool result = _service.DelSaltCalculation((Guid)id); 

            if (!result)
            {
                return NotFound();
            }
            return RedirectToPage("./Index");
        }
        private async Task<bool> SaltCalculationExists(Guid id)
        {
            var saltCalculation = await _service.GetSaltCalculationById(id);
            return saltCalculation != null;
        }
    }
}

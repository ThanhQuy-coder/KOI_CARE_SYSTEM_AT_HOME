using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.SaltCalculationPages
{
    public class DetailsModel : PageModel
    {
        private readonly ISaltCalculationService _service;

        public DetailsModel(ISaltCalculationService service)
        {
            _service = service;
        }

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
            else
            {
                SaltCalculation = saltcalculation;
            }
            return Page();
        }
    }
}

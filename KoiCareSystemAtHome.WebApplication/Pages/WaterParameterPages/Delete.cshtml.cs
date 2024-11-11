using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.WaterParameterPages
{
    public class DeleteModel : PageModel
    {
        private readonly IWaterParameterService _service;

        public DeleteModel(IWaterParameterService service)
        {
            _service = service;
        }

        [BindProperty]
        public WaterParameter WaterParameter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)

            {
                return NotFound();
            }

            var waterparameter = await _service.GetWaterParameterById((Guid)id);

            if (waterparameter == null)
            {
                return NotFound();
            }
            else
            {
                WaterParameter = waterparameter;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _service.DelWaterParameter((Guid)id);
            return RedirectToPage("./Index");
        }
    }
}

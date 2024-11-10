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
using System.Reflection.Metadata;

namespace KoiCareSystemAtHome.WebApplication.Pages.WaterParameterPages
{
    public class EditModel : PageModel
    {
        private readonly IWaterParameterService _service;

        public EditModel(IWaterParameterService service)
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

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool result = _service.UppWaterParameter(WaterParameter);
            if (!result)
            {
                if (!await WaterParameterExists(WaterParameter.WaterParameterId))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception("Loi cap nhat thong so nuoc.");
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> WaterParameterExists(Guid id)
        {
            var WaterParameter = await _service.GetWaterParameterById(id);
            return WaterParameter != null;
        }
    }
}

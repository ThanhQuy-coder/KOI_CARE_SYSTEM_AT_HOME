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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingWaterParameter = await _service.GetWaterParameterById(WaterParameter.WaterParameterId);
            if (existingWaterParameter == null)
            {
                return NotFound();
            }

            // Cập nhật các trường cần thiết
            existingWaterParameter.Temperature = WaterParameter.Temperature;
            existingWaterParameter.SaltLevel = WaterParameter.SaltLevel;
            existingWaterParameter.PH = WaterParameter.PH;
            existingWaterParameter.Oxygen = WaterParameter.Oxygen;
            existingWaterParameter.Nitrie = WaterParameter.Nitrie;
            existingWaterParameter.Nitrate = WaterParameter.Nitrate;
            existingWaterParameter.Phospate = WaterParameter.Phospate;
            existingWaterParameter.MeasurementTime = WaterParameter.MeasurementTime;

            bool result = _service.UppWaterParameter(existingWaterParameter);
            if (!result)
            {
                throw new Exception("Lỗi cập nhật thông số nước.");
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

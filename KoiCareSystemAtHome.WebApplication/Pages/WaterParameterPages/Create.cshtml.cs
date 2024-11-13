using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.WaterParameterPages
{
    public class CreateModel : PageModel
    {
        private readonly IWaterParameterService _service;

        public CreateModel(IWaterParameterService service)
        {
            _service = service;
        }
        [BindProperty]
        public WaterParameter WaterParameter { get; set; } = default!;

        // Nhận PondId từ query string trong URL
        public IActionResult OnGet(Guid pondId)
        {
            // Gán PondId vào Thông số nước
            WaterParameter = new WaterParameter { PondId = pondId };
            return Page();
        }

        public IActionResult OnPost()
        {
            if (WaterParameter.PondId == Guid.Empty)
            {
                ModelState.AddModelError(string.Empty, "PondId is required.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _service.AddWaterParameter(WaterParameter);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error adding.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
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
        public IActionResult OnGet()
        {
            return Page();
        }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _service.AddWaterParameter(WaterParameter);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error adding WaterParameter.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

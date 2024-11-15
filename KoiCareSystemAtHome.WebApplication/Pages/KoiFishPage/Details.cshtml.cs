using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.KoiFishPage
{
    public class DetailsModel : PageModel
    {
        private readonly IKoiFishService _service;

        public DetailsModel(IKoiFishService service)
        {
            _service = service;
        }

        public KoiFish KoiFish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var koiFish = await _service.GetKoiFishById(id);
            if (koiFish == null)
            {
                return NotFound();
            }
            KoiFish = koiFish;
            return Page();
        }
    }
}

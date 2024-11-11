using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.PondPage
{
    public class DetailsModel : PageModel
    {
        private readonly IPondService _service;

        public DetailsModel(IPondService service)
        {
            _service = service;
        }

        public Pond Pond { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {

            if (id == null)
            {

                return NotFound();
            }


            var pond = await _service.GetPondById((Guid)id);
            if (pond == null)
            {
                return NotFound();
            }
            else
            {
                Pond = pond;
            }

            return Page();
        }
    }
}
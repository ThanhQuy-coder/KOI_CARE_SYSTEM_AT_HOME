using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.KoiFishPage
{
    public class DeleteModel : PageModel
    {
        private readonly IKoiFishService _service;

        public DeleteModel(IKoiFishService service)
        {
            _service = service;
        }

        [BindProperty]
        public KoiFish KoiFish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            
            if (id == null)
            {
               
                return NotFound();
            }
         

            var koifish = await _service.GetKoiFishById((Guid)id); 

            if (koifish == null)
            {
                return NotFound();
            }
            else
            {
                KoiFish = koifish;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
            
                return NotFound();
            }
          

            var koifish = await _service.GetKoiFishById((Guid)id);

            return RedirectToPage("./Index");
        }
    }
}

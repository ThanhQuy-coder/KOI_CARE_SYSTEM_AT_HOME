using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.WebApplication.Pages.PondPage
{
    public class DetailsModel : PageModel
    {
        private readonly KoiCareSystemAtHome.Repositories.Entities.KoiCareSystemAtHomeContext _context;

        public DetailsModel(KoiCareSystemAtHome.Repositories.Entities.KoiCareSystemAtHomeContext context)
        {
            _context = context;
        }

        public Pond Pond { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pond = await _context.Ponds.FirstOrDefaultAsync(m => m.PondId == id);
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

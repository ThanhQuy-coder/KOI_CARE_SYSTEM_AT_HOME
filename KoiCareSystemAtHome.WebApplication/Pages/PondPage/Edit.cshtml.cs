using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.WebApplication.Pages.PondPage
{
    public class EditModel : PageModel
    {
        private readonly KoiCareSystemAtHome.Repositories.Entities.KoiCareSystemAtHomeContext _context;

        public EditModel(KoiCareSystemAtHome.Repositories.Entities.KoiCareSystemAtHomeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pond Pond { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pond =  await _context.Ponds.FirstOrDefaultAsync(m => m.PondId == id);
            if (pond == null)
            {
                return NotFound();
            }
            Pond = pond;
           ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
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

            _context.Attach(Pond).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PondExists(Pond.PondId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PondExists(string id)
        {
            return _context.Ponds.Any(e => e.PondId == id);
        }
    }
}

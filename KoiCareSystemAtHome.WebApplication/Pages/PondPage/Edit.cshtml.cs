using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.PondPage
{
    public class EditModel : PageModel
    {
        private readonly IPondService _service;

        public EditModel(IPondService service)
        {
            _service = service;
        }

        [BindProperty]
        public Pond Pond { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var pond = await _service.GetPondById(id);
            if (pond == null)
            {
                return NotFound();
            }

            Pond = pond;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool result = _service.UpdatePond(Pond);

            if (!result)
            {
                if (!await PondExists(Pond.PondId))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception("Lỗi cập nhật hồ.");
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> PondExists(string pondId)
        {
            throw new NotImplementedException();
        }
    }
}
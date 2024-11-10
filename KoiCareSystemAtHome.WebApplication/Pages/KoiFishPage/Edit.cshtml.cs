using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.KoiFishPage
{
    public class EditModel : PageModel
    {
        private readonly IKoiFishService _service;

        public EditModel(IKoiFishService service)
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

            KoiFish = koifish;

            // Nếu cần danh sách PondId cho dropdown
            // ViewData["PondId"] = new SelectList(await _service.GetAllPonds(), "PondId", "PondId");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool result = _service.UpdateKoiFish(KoiFish);

            if (!result)
            {
                if (!await KoiFishExists(KoiFish.FishId))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception("Lỗi cập nhật cá koi.");
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> KoiFishExists(Guid id)
        {
            var koiFish = await _service.GetKoiFishById(id);
            return koiFish != null;
        }
    }
}

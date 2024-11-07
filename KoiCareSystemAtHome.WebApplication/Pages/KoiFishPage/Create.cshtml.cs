using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.KoiFishPage
{
    public class CreateModel : PageModel
    {
        private readonly IKoiFishService _service;

        public CreateModel(IKoiFishService service)
        {
            _service = service;
        }

        [BindProperty]
        public KoiFish KoiFish { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _service.AddKoiFish(KoiFish);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error adding Koi Fish.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

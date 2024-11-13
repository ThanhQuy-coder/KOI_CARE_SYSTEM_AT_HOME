using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.PondPage

{
    public class CreateModel : PageModel
    {
        private readonly IPondService _service;

        public CreateModel(IPondService service)
        {
            _service = service;
        }

        [BindProperty]
        public Pond Pond { get; set; } = default!;

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

            var result = _service.AddPond(Pond);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error adding Pond.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
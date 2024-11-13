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

        // Nhận UserId từ query string trong URL
        public IActionResult OnGet(Guid userId)
        {
            // Gán UserId vào Pond
            Pond = new Pond { UserId = userId };
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Pond.UserId == Guid.Empty)
            {
                ModelState.AddModelError(string.Empty, "PondId is required.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _service.AddPond(Pond);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error adding Koi Fish.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.WebApplication.Pages.NewsPage
{
    public class EditModel : PageModel
    {
        private readonly INewsService _newsService;

        public EditModel(INewsService newsService)
        {
            _newsService = newsService;
        }

        [BindProperty]
        public News News { get; set; } = default!;

        // Thêm thuộc tính để bind file ảnh từ form
        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            News = await _newsService.GetNewsByIdAsync(id);

            if (News == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Gọi phương thức UpdateNews và truyền thêm tham số ImageFile
            _newsService.UpdateNews(News, ImageFile);

            return RedirectToPage("./Index");
        }
    }
}

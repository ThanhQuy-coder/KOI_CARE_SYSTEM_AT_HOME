using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystemAtHome.WebApplication.Pages.Categories
{
    public class DeleteCategoryModel : PageModel
    {
        private readonly ICategoriesService _categoriesService;

        [BindProperty]
        public Category Category { get; set; }

        public DeleteCategoryModel(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Category = await _categoriesService.GetCategoryByIdAsync(id);
            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _categoriesService.DeleteCategoryAsync(id);
            return RedirectToPage("Index");
        }
    }
}

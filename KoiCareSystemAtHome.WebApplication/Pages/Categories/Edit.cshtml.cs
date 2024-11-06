using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystemAtHome.WebApplication.Pages.Categories
{
    public class EditCategoryModel : PageModel
    {
        private readonly ICategoriesService _categoriesService;

        [BindProperty]
        public Category Category { get; set; }

        public EditCategoryModel(ICategoriesService categoriesService)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _categoriesService.UpdateCategoryAsync(Category);
            return RedirectToPage("Index");
        }
    }
}

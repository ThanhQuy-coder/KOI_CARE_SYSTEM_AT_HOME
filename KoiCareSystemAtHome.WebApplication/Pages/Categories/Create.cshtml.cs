using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystemAtHome.WebApplication.Pages.Categories
{
    public class CreateCategoryModel : PageModel
    {
        private readonly ICategoriesService _categoriesService;

        [BindProperty]
        public Category Category { get; set; }

        public CreateCategoryModel(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _categoriesService.AddCategoryAsync(Category);
            return RedirectToPage("Index");
        }
    }
}


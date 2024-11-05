using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystemAtHome.WebApplication.Pages.Categories
{
    public class CategoriesIndexModel : PageModel
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesIndexModel(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public IList<Category> Categories { get; set; }

        public async Task OnGetAsync()
        {
            Categories = (await _categoriesService.GetAllCategoriesAsync()).ToList();
        }
    }
}
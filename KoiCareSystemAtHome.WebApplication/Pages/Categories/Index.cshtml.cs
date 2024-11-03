using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiCareSystemAtHome.WebApplication.Pages.Categories
{
    public class CategoriesModel : PageModel
    {
        private readonly YourDbContext _context;

        public CategoriesModel(YourDbContext context)
        {
            _context = context;
        }

        public IList<Category> Categories { get; set; }

        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.ToListAsync();
        }
    }
}

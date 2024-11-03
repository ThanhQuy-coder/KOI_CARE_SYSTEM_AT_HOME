using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiCareSystemAtHome.WebApplication.Pages.Articles
{
    public class ArticlesModel : PageModel
    {
        private readonly YourDbContext _context;

        public ArticlesModel(YourDbContext context)
        {
            _context = context;
        }

        public IList<Article> Articles { get; set; }

        public async Task OnGetAsync()
        {
            Articles = await _context.Articles.Include(a => a.Category).ToListAsync();
        }
    }
using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiCareSystemAtHome.WebApplication.Pages.Comments
{
    public class CommentsModel : PageModel
    {
        private readonly YourDbContext _context;

        public CommentsModel(YourDbContext context)
        {
            _context = context;
        }

        public IList<Comment> Comments { get; set; }

        public async Task OnGetAsync()
        {
            Comments = await _context.Comments.Include(c => c.Article).ToListAsync();
        }
    }
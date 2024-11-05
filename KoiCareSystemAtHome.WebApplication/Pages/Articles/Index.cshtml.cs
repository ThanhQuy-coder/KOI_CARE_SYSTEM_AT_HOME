using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystemAtHome.WebApplication.Pages.Articles
{
    public class ArticlesIndexModel : PageModel
    {
        private readonly IArticlesService _articlesService;

        public ArticlesIndexModel(IArticlesService articlesService)
        {
            _articlesService = articlesService;
        }

        public IList<Article> Articles { get; set; }

        public async Task OnGetAsync()
        {
            Articles = (await _articlesService.GetAllArticlesAsync()).ToList();
        }
    }
}
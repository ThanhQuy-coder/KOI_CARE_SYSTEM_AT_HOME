using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystemAtHome.WebApplication.Pages
{
    public class KoiIndexModel
    {
        private readonly ILogger<KoiIndexModel> _logger;

        public KoiIndexModel(ILogger<KoiIndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}

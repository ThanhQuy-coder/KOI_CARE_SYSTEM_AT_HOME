using Microsoft.AspNetCore.Mvc;

namespace KoiCareSystemAtHome.WebApplication.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace KoiCareSystemAtHome.WebApplication.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

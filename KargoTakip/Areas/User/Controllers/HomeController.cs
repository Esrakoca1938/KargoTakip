using Microsoft.AspNetCore.Mvc;

namespace KargoTakip.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace SP_MT.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

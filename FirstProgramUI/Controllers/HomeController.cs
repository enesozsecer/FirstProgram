using Microsoft.AspNetCore.Mvc;

namespace FirstProgramUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

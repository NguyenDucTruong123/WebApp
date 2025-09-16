using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class OtherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

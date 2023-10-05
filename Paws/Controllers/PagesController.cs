using Microsoft.AspNetCore.Mvc;

namespace Paws.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult Reviews()
        {
            return View();
        }
    }
}

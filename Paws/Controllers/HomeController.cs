using Microsoft.AspNetCore.Mvc;
using Paws.Models;
using System.Diagnostics;

namespace Paws.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult IndexPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VolunteerResponsibilities()
        {
            return View();
        }
    }
}
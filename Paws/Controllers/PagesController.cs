using Microsoft.AspNetCore.Mvc;
using Paws.Data;
using Paws.Models;





namespace Paws.Controllers
{
    public class PagesController : Controller
    {
        private readonly mvcAppDbContext _dbContext;

        public PagesController(mvcAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }    

        [HttpGet]
        public IActionResult Reviews()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Blank()
        {
            return View();
        }
    }
}

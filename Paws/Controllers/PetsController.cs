using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Paws.Data;
using Paws.Models;

namespace Paws.Controllers
{
    public class PetsController : Controller
    {
        private readonly mvcAppDbContext _dbContext;

        public PetsController(mvcAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Addnew()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Addnew(Pet Application)
        {

            if (ModelState.IsValid)
            {
                _dbContext.Pets.Add(Application);   
                _dbContext.SaveChanges(); 
                return RedirectToAction("Petlist");
            }
            else
            {
                return View(Application);
            }
        }

        [HttpGet]
        public IActionResult Petlist()
        {
            var interns = _dbContext.Pets.ToList(); 
            return View(interns); 
        }
    }
}

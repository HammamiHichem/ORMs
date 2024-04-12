using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers
{
    public class ChefController : Controller
    {
        private readonly MyContext _context;

        public ChefController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var chefs = _context.Chefs.ToList();
            return View(chefs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Chef chef)
{
    if (ModelState.IsValid)
    {
        _context.Chefs.Add(chef);
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
    return View(chef);
}

    }
}

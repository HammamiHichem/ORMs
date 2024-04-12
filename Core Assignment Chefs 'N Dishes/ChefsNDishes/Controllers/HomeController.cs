using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var chefs = _context.Chefs.ToList();
            return View(chefs);
        }

        public IActionResult Dishes()
        {
            var dishes = _context.Dishes.ToList();
            return View(dishes);
        }
    }
}

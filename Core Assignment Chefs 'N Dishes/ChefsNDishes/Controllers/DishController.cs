using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers
{
    public class DishController : Controller
    {
        private readonly MyContext _dbContext;

        public DishController(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var dishes = _dbContext.Dishes.ToList();
            return View(dishes);
        }

        public IActionResult New()
        {
            // Code pour la vue "New" pour ajouter un plat
            return View();
        }
    }
}

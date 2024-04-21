using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new MyViewModel
            {
                AllCategories = _context.Categories.ToList(),
                AllProducts = _context.Products.ToList()
            };
            return View(model);
        }

        [HttpGet("/product")]
        public IActionResult Product()
        {
            var model = new MyViewModel
            {
                AllProducts = _context.Products.ToList()
            };
            return View(model);
        }

        [HttpPost("/add/Product")]
        public IActionResult AddProduct(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("Product");
            }
            else
            {
                var model = new MyViewModel
                {
                    AllProducts = _context.Products.ToList()
                };
                return View("Product", model);
            }
        }

        [HttpGet("/association")]
        public IActionResult Association()
        {
            var model = new MyViewModel
            {
                AllCategories = _context.Categories.ToList(),
                AllProducts = _context.Products.ToList()
            };
            return View(model);
        }

        [HttpPost("/association/add")]
        public IActionResult AddAssociation(Association newAssociation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newAssociation);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Association");
        }

        // Other controller actions...

    }
}

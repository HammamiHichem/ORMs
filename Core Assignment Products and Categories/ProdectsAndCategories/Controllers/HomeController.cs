using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models; // Assurez-vous de spécifier le bon espace de noms où se trouve ErrorViewModel


namespace ProdectsAndCategories.Controllers
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
            var allProducts = _context.Products.Include(p => p.Associations).ThenInclude(pc => pc.Category).ToList();
            return View(allProducts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpPost("/add/category")]
        public IActionResult AddCategory(Category newCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newCategory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var categories = _context.Categories.Include(c => c.Associations).ThenInclude(pc => pc.Product).ToList();
                return View("Index", categories);
            }
        }

        [HttpGet("/product")]
        public IActionResult Product()
        {
            var allProducts = _context.Products.Include(p => p.Associations).ThenInclude(pc => pc.Category).ToList();
            var myModel = new MyViewModel
            {
                AllProducts = allProducts,
            };
            return View(myModel);
        }

        [HttpPost("/add/product")]
        public IActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet("/association")]
        public IActionResult Association()
        {
            ViewBag.AllCategories = _context.Categories.ToList();
            ViewBag.AllProducts = _context.Products.ToList();
            return View();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private class MyViewModel
        {
            public List<Product>? AllProducts { get; set; }
        }
    }
}

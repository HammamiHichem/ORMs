using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;
using System.Diagnostics;
using System.Linq;

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

        // Action pour afficher la liste des produits
        public IActionResult Index()
        {
            var allProducts = _context.Products.Include(p => p.Associations).ThenInclude(pc => pc.Category).ToList();
    return View(allProducts);
        }

        // Action pour afficher la page d'ajout de produit
        [HttpGet("/AddProduct")]
        public IActionResult ProductForm()
        {
            return View();
        }

        // Action pour traiter la soumission du formulaire d'ajout de produit
        [HttpPost("/add/product")]
        public IActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("ProductForm", product); 
        }

        // Action pour afficher la page d'ajout de catégorie
        public IActionResult CategoryForm()
        {
            return View();
        }

        // Action pour traiter la soumission du formulaire d'ajout de catégorie
        [HttpPost("/add/category")]
        public IActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var categories = _context.Categories.Include(c => c.Associations).ThenInclude(pc => pc.Product).ToList();
                return View("Index", categories);
            }
        }

        // Action pour afficher la page d'association entre produits et catégories
        [HttpGet("/association")]
        public IActionResult Association()
        {
            ViewBag.AllCategories = _context.Categories.ToList();
            ViewBag.AllProducts = _context.Products.ToList();
            return View();
        }

        // Action pour traiter la soumission du formulaire d'association entre produits et catégories
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

        // Action pour afficher la page d'erreur
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

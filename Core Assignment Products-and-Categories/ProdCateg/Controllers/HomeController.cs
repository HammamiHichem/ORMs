using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // Actions pour afficher les produits, les catégories et gérer les associations

        public IActionResult Index()
        {
            var viewModel = new MyViewModel
            {
                AllCategories = _context.Categories.ToList()
            };
            return View(viewModel);
        }

        [HttpPost("/Home/Products")]
        public IActionResult AddProduct(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var viewModel = new MyViewModel
                {
                    Product = newProduct,
                    AllProducts = _context.Products.ToList()
                };
                return View("_AddProduct", viewModel);
            }
        }

        [HttpGet("/Home/Products")]
        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        [HttpGet("/Home/Categories")]
        public IActionResult GetCategories()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // Actions pour ajouter une nouvelle catégorie

        [HttpPost("/Home/Categories")]
        public IActionResult AddCategory(Category newCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newCategory);
                _context.SaveChanges();
                
                var viewModel = new MyViewModel
                {
                    AllCategories = _context.Categories.ToList()
                };
                
                return View("Category", viewModel);
            }
            else
            {
                return View("Category");
            }
        }

        // Méthode pour ajouter une association entre un produit et une catégorie
[HttpPost("/Home/AddProductCategory")]
public IActionResult AddProductCategory(int productId, int categoryId)
{
    // Vérifiez d'abord si cette association existe déjà
    var existingAssociation = _context.Associations
        .FirstOrDefault(a => a.ProductId == productId && a.CategoryId == categoryId);

    if (existingAssociation != null)
    {
        // L'association existe déjà, retournez un message d'erreur ou effectuez une action appropriée
        return BadRequest("Cette association existe déjà.");
    }

    // Si l'association n'existe pas, créez une nouvelle instance de l'association
    var newAssociation = new Association { ProductId = productId, CategoryId = categoryId };

    // Ajoutez la nouvelle association à la base de données
    _context.Add(newAssociation);
    _context.SaveChanges();

    // Redirigez vers une action appropriée ou renvoyez une réponse réussie
    return RedirectToAction("Index");
}

// Méthode pour supprimer une association entre un produit et une catégorie
[HttpPost("/Home/DeleteProductCategory")]
public IActionResult DeleteProductCategory(int productId, int categoryId)
{
    // Recherchez l'association dans la base de données
    var associationToRemove = _context.Associations
        .FirstOrDefault(a => a.ProductId == productId && a.CategoryId == categoryId);

    if (associationToRemove != null)
    {
        // Supprimez l'association de la base de données
        _context.Remove(associationToRemove);
        _context.SaveChanges();
    }

    // Redirigez vers une action appropriée ou renvoyez une réponse réussie
    return RedirectToAction("Index");
}


        // Actions pour gérer les associations entre catégories et produits

        [HttpGet("/association")]
        public IActionResult Association()
        {
            ViewBag.AllCategories = _context.Categories.ToList();
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

        // Action pour gérer les erreurs

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

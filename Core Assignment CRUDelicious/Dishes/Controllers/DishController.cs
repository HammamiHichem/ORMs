using Microsoft.AspNetCore.Mvc;
using Dishes.Models;
using System.Linq;

namespace Dishes.Controllers
{
    public class DishController : Controller
    {
        private readonly MyContext _dbContext;

        public DishController(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Action pour afficher le formulaire d'ajout d'un nouveau plat
        public IActionResult NewDish()
        {
            return View();
        }

        // Action pour traiter la soumission du formulaire et ajouter un nouveau plat
        [HttpPost]
        public IActionResult CreateDish(Dish dish)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Dishes.Add(dish);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View("NewDish", dish);
        }

        // Action pour afficher les détails d'un plat spécifique
        public IActionResult ViewDish(int id)
        {
            var dish = _dbContext.Dishes.FirstOrDefault(d => d.DishId == id);
            if (dish == null)
            {
                return NotFound(); // Retourne une erreur 404 si le plat n'est pas trouvé
            }
            return View(dish);
        }

        // Action pour supprimer un plat spécifique
        [HttpPost]
        public IActionResult DeleteDish(int id)
        {
            var dish = _dbContext.Dishes.FirstOrDefault(d => d.DishId == id);
            if (dish == null)
            {
                return NotFound(); // Retourne une erreur 404 si le plat n'est pas trouvé
            }

            _dbContext.Dishes.Remove(dish); // Supprimer le plat de la base de données
            _dbContext.SaveChanges(); // Sauvegarder les modifications

            return RedirectToAction("Index", "Home"); // Rediriger vers la page d'accueil après la suppression
        }

        // Action pour afficher le formulaire d'édition d'un plat spécifique
        public IActionResult EditDish(int id)
        {
            var dish = _dbContext.Dishes.FirstOrDefault(d => d.DishId == id);
            if (dish == null)
            {
                return NotFound(); // Retourne une erreur 404 si le plat n'est pas trouvé
            }
            return View(dish);
        }

        // Action pour traiter la soumission du formulaire d'édition et mettre à jour le plat
        [HttpPost]
        public IActionResult UpdateDish(Dish dish)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Dishes.Update(dish); // Mettre à jour le plat dans la base de données
                _dbContext.SaveChanges(); // Sauvegarder les modifications
                return RedirectToAction("Index", "Home"); // Rediriger vers la page d'accueil après la mise à jour
            }
            return View("EditDish", dish);
        }
    }
}

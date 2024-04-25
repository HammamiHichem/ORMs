// AddProductCategoryViewModel.cs
using ProductsAndCategories.Models;

namespace ProductsAndCategories.ViewModels
{
    public class AddProductCategoryViewModel
    {
        // Propriétés nécessaires pour ajouter une association produit-catégorie
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}

// DeleteProductCategoryViewModel.cs
#pragma warning disable CS8618
using ProductsAndCategories.Models;

namespace ProductsAndCategories.ViewModels
{
    public class DeleteProductCategoryViewModel
    {
        // Propriétés nécessaires pour supprimer une association produit-catégorie
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}

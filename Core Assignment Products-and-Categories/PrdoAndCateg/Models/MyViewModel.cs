#pragma warning disable CS8618

using System.Collections.Generic; // Ajout de cette directive

namespace ProductsAndCategories.Models
{
    public class MyViewModel
    {
        public Product Product { get; set; }
        public List<Product> AllProducts { get; set; }
        public Category Category { get; set; }
        public List<Category> AllCategories { get; set; }
    }
}

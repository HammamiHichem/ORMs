#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace ProductsAndCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Modifier cette propriété pour qu'elle soit une liste de Category
        public List<Category> AllCategories { get; set; }
    }
}
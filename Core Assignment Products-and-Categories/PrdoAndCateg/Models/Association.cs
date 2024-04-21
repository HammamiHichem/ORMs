using System.ComponentModel.DataAnnotations;

namespace ProductsAndCategories.Models
{
    public class Association
    {
        [Key]
        public int AssociationId { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}

#pragma warning disable CS8618
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsAndCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal Price { get; set; }

        // Navigation property
        public ICollection<Association> Associations { get; set; }
    }
}


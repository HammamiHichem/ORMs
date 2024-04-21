#pragma warning disable CS8618
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsAndCategories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        // Navigation property
        public ICollection<Association> Associations { get; set; }
    }
}

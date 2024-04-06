using System;
using System.ComponentModel.DataAnnotations;

namespace Dishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        [MaxLength(45)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Chef is required")]
        [Display(Name = "Chef")]
        [MaxLength(45)]
        public string Chef { get; set; }

        [Required(ErrorMessage = "Tastiness is required")]
        [Display(Name = "Tastiness")]
        public int Tastiness { get; set; }

        [Required(ErrorMessage = "Calories is required")]
        [Display(Name = "Calories")]
        public int Calories { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        [MaxLength(255)]
        public string Description { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated At")]
        public DateTime UpdatedAt { get; set; }
    }
}

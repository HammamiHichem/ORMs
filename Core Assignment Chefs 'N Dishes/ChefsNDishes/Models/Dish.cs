#pragma warning disable CS8618
using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models 
{
    public class Dish
    {
        public int DishId { get; set; }

        [Required(ErrorMessage = "Le champ nom du plat est requis")]
        [Display(Name = "Nom du plat")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le champ calories est requis")]
        [Range(1, int.MaxValue, ErrorMessage = "Les calories doivent être supérieures à 0")]
        public int Calories { get; set; }

        [Required(ErrorMessage = "Le champ goût est requis")]
        [Range(1, 5, ErrorMessage = "Le goût doit être compris entre 1 et 5")]
        [Display(Name = "Goût")]
        public int Tastiness { get; set; }

        public int ChefId { get; set; }
        public Chef Chef { get; set; }

        [Display(Name = "Date de création")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Date de mise à jour")]
        public DateTime UpdatedAt { get; set; }

        public Dish()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

#pragma warning disable CS8618
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models 
{
    public class Chef
    {
        public int ChefId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public List<Dish> Dishes { get; set; } // Navigation property for One-to-Many relationship

        [Display(Name = "Date de création")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Date de mise à jour")]
        public DateTime UpdatedAt { get; set; }

        public int CalculateAge()
        {
            var now = DateTime.UtcNow;
            var age = (int)Math.Floor((now.Subtract(DateOfBirth).TotalDays / 365.25));
            return age;
        }

        public Chef()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

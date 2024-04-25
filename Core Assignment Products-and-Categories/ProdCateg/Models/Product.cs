#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models;


public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    [MinLength(2)]
    public string Name { get; set; }
    [Required]
    [MinLength(3)]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }

    // Navigation properties
    public List<Association> AllCategories { get; set; } = new List<Association>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


}
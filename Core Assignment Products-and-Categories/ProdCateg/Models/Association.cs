#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models;


public class Association

{
    [Key]
    public int AssociationID { get; set; }


    // Track the IDs of our joining models
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int CategoryId { get; set; }


    // Navigation properties
    public Product Product { get; set; }
    public Category Category { get; set; }






}
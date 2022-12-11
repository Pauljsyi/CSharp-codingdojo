#pragma warning disable CS8618;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsDishes.Models;
public class Dish
{
    [Key]
    public int DishId {get;set;}
    [Required]
    public string DishName {get;set;}
    [Required]
    public int NumOfCalories {get;set;}
    [Required]
    public int Tastiness {get;set;}
    // foreign key
    [Required]
    public int? ChefId {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    // navigation property to track Chef's Dishes
    public Chef? Creator {get;set;}

}
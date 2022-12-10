#pragma warning disable CS8618;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsDishes.Models;
public class Chef
{
    [Key]
    public int DishId {get;set;}
    public string DishName {get;set;}
    public int NumOfCalories {get;set;}
    public int Tastiness {get;set;}
    // foreign key
    public int ChefId {get;set;}

    // navigation property to track Chef's Dishes
    public Chef? Creator {get;set;}

}
#pragma warning disable CS8618;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsDishes.Models;
public class Chef
{
    [Key]
    public int ChefId {get;set;}
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public DateOnly Birthdate {get;set;}

    // navigation property will not map to our database
    public List<Dish> CreatedDishes {get;set;} = new List<Dish>();

}
#pragma warning disable CS8618;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsDishes.Models;
public class Chef
{
    [Key]
    public int ChefId {get;set;}
    [Required]
    public string FirstName {get;set;}
    [Required]
    public string LastName {get;set;}
    [Required]
    public DateTime Birthdate {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    // navigation property will not map to our database
    public List<Dish> CreatedDishes {get;set;} = new List<Dish>();

}
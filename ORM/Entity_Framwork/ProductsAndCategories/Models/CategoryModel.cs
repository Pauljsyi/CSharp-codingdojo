#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProductsAndCategories.Models;
public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string Name { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Association> ByCategory {get;set;} = new List<Association>();

    // public Association Association {get;set;}
    // public List<Association> ProductsWithCategories {get;set;} = new List<Association>();
}
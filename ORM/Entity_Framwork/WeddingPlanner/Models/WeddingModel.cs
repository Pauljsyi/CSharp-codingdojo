#pragma warning disable CS8618;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;
public class Wedding
{
    [Key]
    public int WeddingId { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Wedder name must be at least 2 characters")]
    public string WedderOne { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Wedder name must be at least 2 characters")]
    public string WedderTwo { get; set; }

    [Required]
    [Range(2022, 9000)]
    public int? Date { get; set; }

    [Required]
    [MinLength(5, ErrorMessage = "Address must be greater than 5 characters")]
    public string Address { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
#pragma warning disable CS8618;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LoginRegDemo.Models;

public class LoginUser {

    [Required]
    [EmailAddress]
    public string Email{get;set;}
    [Required]
    [DataType(DataType.Password)]  //  -> shows dots instead of exposed password
    public string Password{get;set;}



}
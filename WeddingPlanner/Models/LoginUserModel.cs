#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models;

[NotMapped]
public class LoginUser
{
    [Required(ErrorMessage = "is required")]
    [EmailAddress]
    [Display(Name =  "LoginEmail")]
    public string LoginEmail { get; set; }
    [Required(ErrorMessage = "is required")]
    [MinLength(8, ErrorMessage = "must be at least 8 chars")]
    [DataType(DataType.Password)]
    [Display(Name = "LoginPassword")]
    public string LoginPassword { get; set; }
}
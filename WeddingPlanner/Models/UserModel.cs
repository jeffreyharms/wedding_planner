#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models;

public class User 
{
    [Key]
    public int UserId { get; set; }
    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least two chars")]
    [Display(Name = "firstName")]
    public string firstName { get; set; }
    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least two chars")]
    [Display(Name = "lastName")]
    public string lastName { get; set; }
    [Required(ErrorMessage = "is required")]
    [EmailAddress(ErrorMessage = "must be a valid email")]
    [Display(Name = "email")]
    public string email { get; set; }
    [Required(ErrorMessage = "is required")]
    [MinLength(8, ErrorMessage = "must be at least 8 chars")]
    [DataType(DataType.Password)]
    [Display(Name = "password")]
    public string password { get; set; }
    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("password", ErrorMessage = "doesn't match password")]
    [Display(Name = "confirmpass")]
    public string confirmpass { get; set; }
    public DateTime created_at { get; set; } = DateTime.Now;
    public DateTime updated_at { get; set; } = DateTime.Now;
}
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models;

public class Wedding
{
    [Required(ErrorMessage = "is required")]
    public int WeddingId { get; set; }
    [Required(ErrorMessage = "is required")]
    public string WedderOne { get; set; }
    [Required(ErrorMessage = "is required")]
    public string WedderTwo { get; set; }
    [Required(ErrorMessage = "is required")]
    [Future]
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "is required")]
    [MinLength(8, ErrorMessage ="must be at least 8 characters")]
    public string Address { get; set; }
    public DateTime Created_At { get; set; } = DateTime.Now;
    public DateTime Updated_At { get; set; } = DateTime.Now;
    public int UserId { get; set; }
    public User? WeddingPlanner { get; set; }
    public List<RSVP>? Guests { get; set; }
} 

public class Future : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }
        DateTime date = (DateTime)value;
        if (date <= DateTime.Now)
        {
            return new ValidationResult("must be a future date");
        }
        return ValidationResult.Success;
    }
}
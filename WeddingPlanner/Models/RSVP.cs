#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models;

public class RSVP
{
    public int RSVPID { get; set; }
    public int WeddingId { get; set; }
    public int UserId { get; set; }
    public User? Guest { get; set; }
}
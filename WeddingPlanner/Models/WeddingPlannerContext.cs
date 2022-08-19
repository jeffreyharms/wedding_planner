#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace WeddingPlanner.Models;

public class WeddingPlannerContext : DbContext
{
    public WeddingPlannerContext(DbContextOptions options) : base(options) { }
    public DbSet<User> User { get; set; }
    public DbSet<Wedding> Wedding { get; set; }
    public DbSet<RSVP> RSVP  { get; set; }
}
using Microsoft.EntityFrameworkCore;
using navitem.Models;

public class ApplicationDbContext : DbContext
{
   

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<NavigationItem> NavigationItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }

  
}
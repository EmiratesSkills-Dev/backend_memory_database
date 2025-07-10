using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.Data;

public class MainContext : DbContext
{
    public MainContext(DbContextOptions<MainContext> options) : base(options)
    {
    }
    public DbSet<Model.Activity> Activities { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Model.Activity>()
            .Property(a => a.Description)
            .IsRequired();
    }
}

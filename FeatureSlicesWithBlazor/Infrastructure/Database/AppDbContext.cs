using Microsoft.EntityFrameworkCore;

namespace FeatureSlicesWithBlazor.Infrastructure.Database;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed test data
        modelBuilder.Entity<User>().HasData(RandomDataGenerator.GenerateUsers());
    }
}

public class User
{
    public Guid UserId { get; set; }
    public string DisplayName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
}

using Microsoft.EntityFrameworkCore;

namespace FlightMonitor.Infrastructure.Database;

public class AppDbContext : DbContext
{
    public DbSet<Flight> Flights => Set<Flight>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed test data
        modelBuilder.Entity<Flight>().HasData(RandomDataGenerator.GenerateFlights());
    }
}

public class Flight
{
    public Guid Id { get; set; }
    public string FlightNumber { get; set; }
    public string Airline { get; set; }
    public string Destination { get; set; }
    public DateTime ScheduledDeparture { get; set; }
    public DateTime ActualDeparture { get; set; }
    public string Gate { get; set; }
    public FlightStatus Status { get; set; }
}

public enum FlightStatus
{
    Scheduled,
    Boarding, 
    Delayed,
    Cancelled
}

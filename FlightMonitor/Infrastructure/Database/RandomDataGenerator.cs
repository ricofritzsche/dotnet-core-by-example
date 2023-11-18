namespace FlightMonitor.Infrastructure.Database;

public static class RandomDataGenerator
{
    private static readonly Random Random = new();

    private static readonly string[] Gates = 
    {
        "A1", "A2", "A3", "B1", "B2", "C1", "C2", "C3", "D1", "D2"
    };

    private static readonly string[] Destinations = 
    {
        "New York", "Los Angeles", "Chicago", "Houston", "Miami", "San Francisco", "Seattle", "London", "Paris", "Tokyo"
    };

    private static readonly string[] Airlines = 
    {
        "Airways One", "Global Air", "Skyline Express", "Oceanic Airlines", "Continental Wings", "Pacific Flight", "Euro Connect", "Atlantic Air", "Safari Skies", "Polar Jet"
    };


    public static Flight[] GenerateFlights()
    {
        var flights = new List<Flight>();

        for (var i = 0; i < 100; i++)
        {
            var airline = Airlines[Random.Next(Airlines.Length)];
            var flightNumber = airline.Substring(0, 2).ToUpper() + Random.Next(1000, 9999);
            var scheduledDeparture = DateTime.Now.AddMinutes(Random.Next(10, 240));
            
            var flight = new Flight
            {
                Id = Guid.NewGuid(),
                Airline = airline,
                Destination = Destinations[Random.Next(Destinations.Length)],
                FlightNumber = flightNumber,
                Gate = Gates[Random.Next(Gates.Length)],
                ScheduledDeparture = scheduledDeparture,
                ActualDeparture = scheduledDeparture,
                Status = FlightStatus.Scheduled
            };

            flights.Add(flight);
        }

        return flights.ToArray();
    }
}
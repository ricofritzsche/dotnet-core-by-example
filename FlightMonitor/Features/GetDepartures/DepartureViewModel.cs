namespace FlightMonitor.Features.GetDepartures;

public record DepartureViewModel(Guid Id, string Time, string Flight, string Destination, string Status);

using FlightMonitor.Infrastructure.Database;

namespace FlightMonitor.Features.EditFlight;

public record FlightEditViewModel(Guid Id, string Flight, string Destination, DateTime Scheduled, DateTime Actual, FlightStatus Status);
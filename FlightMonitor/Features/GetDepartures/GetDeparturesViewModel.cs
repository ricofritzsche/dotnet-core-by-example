using FlightMonitor.Infrastructure.Database;

namespace FlightMonitor.Features.GetDepartures;

public record GetDeparturesViewModel(IEnumerable<DepartureViewModel> Departures);
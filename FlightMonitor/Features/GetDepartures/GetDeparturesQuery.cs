using MediatR;

namespace FlightMonitor.Features.GetDepartures;

public record GetDeparturesQuery() : IRequest<GetDeparturesViewModel>;
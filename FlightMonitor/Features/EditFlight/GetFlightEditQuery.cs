using MediatR;

namespace FlightMonitor.Features.EditFlight;

public record GetFlightEditQuery(Guid Id) : IRequest<FlightEditViewModel>;
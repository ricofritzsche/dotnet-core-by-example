using MediatR;

namespace FlightMonitor.Features.EditFlight;

public record SetDelayCommand(Guid Id, uint DelayInMinutes) : IRequest;

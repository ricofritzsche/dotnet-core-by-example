using MediatR;

namespace FlightMonitor.Features.EditFlight;

public record FlightUpdatedNotification(Guid Id) : INotification;
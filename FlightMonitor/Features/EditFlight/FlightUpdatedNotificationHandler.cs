using FlightMonitor.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace FlightMonitor.Features.EditFlight;

public class FlightUpdatedNotificationHandler(IHubContext<FlightHub> hubContext) : INotificationHandler<FlightUpdatedNotification>
{
    public async Task Handle(FlightUpdatedNotification notification, CancellationToken cancellationToken)
    {
        // Send a message to all clients to refresh their flight list
        await hubContext.Clients.All.SendAsync("RefreshFlightList", cancellationToken);
    }
}

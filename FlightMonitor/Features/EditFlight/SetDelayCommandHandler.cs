using FlightMonitor.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlightMonitor.Features.EditFlight;

public class SetDelayCommandHandler(AppDbContext dbContext, IMediator publisher) : IRequestHandler<SetDelayCommand>
{
    public async Task Handle(SetDelayCommand request, CancellationToken cancellationToken)
    {
        var flight = await dbContext.Flights.SingleAsync(f => f.Id == request.Id, cancellationToken);
        
        flight.ActualDeparture = flight.ActualDeparture.AddMinutes(request.DelayInMinutes);
        flight.Status = FlightStatus.Delayed;
        
        await dbContext.SaveChangesAsync(cancellationToken);
        
        await publisher.Publish(new FlightUpdatedNotification(flight.Id), cancellationToken);
    }
}
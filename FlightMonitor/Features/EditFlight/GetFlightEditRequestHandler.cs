using FlightMonitor.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlightMonitor.Features.EditFlight;

public class GetFlightEditRequestHandler(IDbContextFactory<AppDbContext> contextFactory)  : IRequestHandler<GetFlightEditQuery, FlightEditViewModel>
{
    public async Task<FlightEditViewModel> Handle(GetFlightEditQuery request, CancellationToken cancellationToken)
    {
        var dbContext = await contextFactory.CreateDbContextAsync(cancellationToken);
        var flight = await dbContext.Flights.SingleAsync(f => f.Id == request.Id, cancellationToken);
        return new FlightEditViewModel(flight.Id, flight.FlightNumber, flight.Destination, flight.ScheduledDeparture, flight.ActualDeparture, flight.Status);
    }
}
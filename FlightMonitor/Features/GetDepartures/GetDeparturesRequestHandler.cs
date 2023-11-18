using FlightMonitor.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlightMonitor.Features.GetDepartures;

public class GetDeparturesRequestHandler(IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<GetDeparturesQuery, GetDeparturesViewModel>
{
    public async Task<GetDeparturesViewModel> Handle(GetDeparturesQuery request, CancellationToken cancellationToken)
    {
        var dbContext = await contextFactory.CreateDbContextAsync(cancellationToken);
        var flights = await dbContext.Flights
            .Take(20)
            .OrderBy(c => c.ScheduledDeparture)
            .ToListAsync(cancellationToken);
    
        
        var viewModels = flights.Select(f => new DepartureViewModel(f.Id, f.ActualDeparture.ToString("hh:mm tt"), f.FlightNumber, f.Destination, f.Status.ToString())).ToList();
    
        var viewModel = new GetDeparturesViewModel(viewModels);
        return viewModel;
    }
}
using FeatureSlicesWithBlazor.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FeatureSlicesWithBlazor.Features.GetUserList;

// Input (Request)
public record GetUserList(int PageSize = 10, int Page = 1) : IRequest<GetUserListViewModel>;

// Output (Response)
public record GetUserListViewModel(IEnumerable<UserViewModel> Users, int TotalRecords, int Page, int TotalPages);

// ViewModel
public record UserViewModel(Guid UserId, string DisplayName);

// Handler, Domain Logic
public class GetUserListRequestHandler(AppDbContext dbContext) : IRequestHandler<GetUserList, GetUserListViewModel>
{
    public async Task<GetUserListViewModel> Handle(GetUserList request, CancellationToken cancellationToken)
    {
        var pageSize = request.PageSize; // The number of records per page
        var pageNumber = request.Page; // The current page number
    
        var skip = (pageNumber - 1) * pageSize;
    
        var totalRecords = await dbContext.Users.CountAsync(cancellationToken);
    
        var users = await dbContext.Users
            .OrderBy(c => c.DisplayName)
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    
        // Map the result to your view model. Assuming you have a mapping method or using a projection
        var viewModels = users.Select(u => new UserViewModel(u.UserId, u.DisplayName)).ToList();
    
        // Create the view model for the current page
        var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
        var viewModel = new GetUserListViewModel(viewModels,  totalRecords, pageNumber, totalPages);
        return viewModel;
    }
}
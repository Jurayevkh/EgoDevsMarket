using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Queries.User;
using EgoDevsMarket.Domain.Entities.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.User;

public class GetAllUsersHandler : IRequestHandler<GetAllUsers, List<Users>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllUsersHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Users>> Handle(GetAllUsers request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Users.ToListAsync();
    }
}

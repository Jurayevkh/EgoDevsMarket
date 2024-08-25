using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Queries.User;
using EgoDevsMarket.Domain.Entities.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.User;

public class GetUserByIdHandler : IRequestHandler<GetUserById, Users>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetUserByIdHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Users> Handle(GetUserById request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Users.FirstOrDefaultAsync(u=>u.Id == request.Id);
    }
}

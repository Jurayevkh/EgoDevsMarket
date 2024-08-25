using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Queries.Branch;
using EgoDevsMarket.Domain.Entities.Branch;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Branch;

public class GetBranchByIdHandler : IRequestHandler<GetBranchById, Branches>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetBranchByIdHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Branches> Handle(GetBranchById request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Branches.FirstOrDefaultAsync(b=>b.Id == request.Id);
    }
}

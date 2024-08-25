using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Queries.Branch;
using EgoDevsMarket.Domain.Entities.Branch;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Branch;

public class GetAllBranchsHandler : IRequestHandler<GetAllBranches, List<Branches>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllBranchsHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Branches>> Handle(GetAllBranches request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Branches.ToListAsync(cancellationToken);
    }
}

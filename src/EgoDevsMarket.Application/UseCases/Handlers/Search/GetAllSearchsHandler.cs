using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Queries.Search;
using EgoDevsMarket.Domain.Entities.Search;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Search;

public class GetAllSearchsHandler : IRequestHandler<GetAllSearchs, List<Searchs>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllSearchsHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Searchs>> Handle(GetAllSearchs request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Searchs.ToListAsync();
    }
}

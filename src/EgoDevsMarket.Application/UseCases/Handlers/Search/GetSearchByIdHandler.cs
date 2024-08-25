using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Queries.Search;
using EgoDevsMarket.Domain.Entities.Search;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Search;

public class GetSearchByIdHandler : IRequestHandler<GetSearchById, Searchs>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetSearchByIdHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Searchs> Handle(GetSearchById request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Searchs.FirstOrDefaultAsync(s=>s.Id==request.Id);
    }
}
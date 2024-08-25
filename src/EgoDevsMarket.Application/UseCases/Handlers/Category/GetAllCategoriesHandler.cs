using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Queries.Category;
using EgoDevsMarket.Domain.Entities.Category;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Category;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategories, List<Categories>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllCategoriesHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Categories>> Handle(GetAllCategories request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Categories.ToListAsync();
    }
}

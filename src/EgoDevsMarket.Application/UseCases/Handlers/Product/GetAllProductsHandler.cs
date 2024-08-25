using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Queries.Product;
using EgoDevsMarket.Domain.Entities.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Product;

public class GetAllProductsHandler : IRequestHandler<GetAllProducts, List<Products>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllProductsHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Products>> Handle(GetAllProducts request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Products.ToListAsync();
    }
}

using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Queries.Product;
using EgoDevsMarket.Domain.Entities.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Product;

public class GetProductByIdHandler : IRequestHandler<GetProductById, Products>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetProductByIdHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Products> Handle(GetProductById request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Products.FirstOrDefaultAsync(p=>p.Id == request.Id);
    }
}

using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Commands.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Product;

public class DeleteProductHandler : IRequestHandler<DeleteProduct, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteProductHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteProduct request, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _applicationDbContext.Products.FirstOrDefaultAsync(p=>p.Id==request.ProductId);  
            if(product is null)
                return false;
            _applicationDbContext.Products.Remove(product);
            var result=await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result>0;
        }
        catch
        {
            return false;
        }
    }
}

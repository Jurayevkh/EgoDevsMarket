using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Queries.Order;
using EgoDevsMarket.Domain.Entities.Order;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Order;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrders, List<Orders>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllOrdersHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<List<Orders>> Handle(GetAllOrders request, CancellationToken cancellationToken)
    {
        return _applicationDbContext.Orders.ToListAsync(cancellationToken);
    }
}

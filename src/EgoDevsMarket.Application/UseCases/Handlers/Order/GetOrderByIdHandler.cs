using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Queries.Order;
using EgoDevsMarket.Domain.Entities.Order;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Order;

public class GetOrderByIdHandler : IRequestHandler<GetOrderById, Orders>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetOrderByIdHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<Orders> Handle(GetOrderById request, CancellationToken cancellationToken)
    {
        return _applicationDbContext.Orders.FirstOrDefaultAsync(o=>o.Id == request.Id);
    }
}

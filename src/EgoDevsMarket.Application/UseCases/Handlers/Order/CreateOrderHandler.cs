using AutoMapper;
using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.DTO.Order;
using EgoDevsMarket.Application.UseCases.Commands.Order;
using EgoDevsMarket.Domain.Entities.Order;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Order;

public class CreateOrderHandler : IRequestHandler<CreateOrder, OrderResultDTO>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly Mapper _mapper;
    public CreateOrderHandler(IApplicationDbContext applicationDbContext, Mapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<OrderResultDTO> Handle(CreateOrder request, CancellationToken cancellationToken)
    {
        Orders order=_mapper.Map<Orders>(request);
        order.CreatedAt=DateTime.UtcNow;
        await _applicationDbContext.Orders.AddAsync(order);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u=>u.Id ==request.UserId);
        var product = await _applicationDbContext.Products.FirstOrDefaultAsync(p=>p.Id==request.ProductId);
        var seller = await _applicationDbContext.Users.FirstOrDefaultAsync(s=>s.Id==product.SellerId);
        var branch = await _applicationDbContext.Branches.FirstOrDefaultAsync(b=>b.Id==request.BranchId);
        OrderResultDTO orderResultDTO= new OrderResultDTO{
            Id=order.Id,
            UserId=request.UserId,
            FullName = user.FirstName+""+user.LastName,
            SellerId = seller.Id,
            SellerName = seller.FirstName+" "+seller.LastName,
            ProductId= product.Id,
            ProductName = product.Name,
            ProductPrice = product.Price,
            BranchId=branch.Id,
            BranchName=branch.Name,
            BranchAddress=branch.Address 
            };
        return orderResultDTO;
    }
}
using EgoDevsMarket.Application.DTO.Order;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.Order;

public class CreateOrder:IRequest<OrderResultDTO>
{
    public int UserId{get;set;}
    public int ProductId{get;set;}
    public int BranchId{get;set;}
    public DateTimeOffset CreatedAt{get;set;}
}
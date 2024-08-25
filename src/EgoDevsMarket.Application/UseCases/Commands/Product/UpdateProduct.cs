using EgoDevsMarket.Application.DTO.Product;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.Product;

public class UpdateProduct:IRequest<ProductResultDTO>
{
    public int Id{get;set;}
    public string? Name{get;set;}
    public decimal Price{get;set;}
    public int CategoryId{get;set;}
    public string? Description{get;set;}
    public string? PhotoLink{get;set;}

}
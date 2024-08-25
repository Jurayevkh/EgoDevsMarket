using EgoDevsMarket.Application.DTO.Product;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.Product;

public class CreateProduct:IRequest<ProductResultDTO>
{
    public string Name{get;set;}
    public decimal Price{get;set;}
    public int SellerId{get;set;}
    public int CategoryId{get;set;}
    public string Description{get;set;}
    public string PhotoLink{get;set;}
    public int SoldQuantity{get;set;}=0;
    
}
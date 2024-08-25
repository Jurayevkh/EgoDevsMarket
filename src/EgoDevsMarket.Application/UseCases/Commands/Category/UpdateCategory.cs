using EgoDevsMarket.Domain.Entities.Category;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.Category;

public class UpdateCategory:IRequest<Categories>
{
    public int Id{get;set;}
    public string? Name{get;set;}
    public string? PhotoLink{get;set;}
}
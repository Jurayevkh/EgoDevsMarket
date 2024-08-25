using EgoDevsMarket.Domain.Entities.Category;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.Category;

public class CreateCategory:IRequest<Categories>
{
    public string Name{get;set;}
    public string PhotoLink{get;set;}
}
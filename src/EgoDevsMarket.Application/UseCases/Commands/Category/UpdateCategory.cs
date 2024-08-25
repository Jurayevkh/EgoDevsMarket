using EgoDevsMarket.Application.DTO.Category;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.Category;

public class UpdateCategory:IRequest<CategoryResultDTO>
{
    public int Id{get;set;}
    public string? Name{get;set;}
    public string? PhotoLink{get;set;}
}
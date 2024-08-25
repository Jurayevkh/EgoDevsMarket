using EgoDevsMarket.Application.DTO.Category;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.Category;

public class CreateCategory:IRequest<CategoryResultDTO>
{
    public string Name{get;set;}
    public string PhotoLink{get;set;}
}
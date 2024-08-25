using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.Category;

public class DeleteCategory:IRequest<bool>
{
    public int CategoryId { get; set; }
}
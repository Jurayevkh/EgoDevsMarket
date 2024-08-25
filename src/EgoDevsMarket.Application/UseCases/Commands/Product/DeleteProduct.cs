using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.Product;

public class DeleteProduct:IRequest<bool>
{
    public int ProductId { get; set; }
}
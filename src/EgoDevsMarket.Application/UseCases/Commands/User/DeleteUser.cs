using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.User;

public class DeleteUser:IRequest<bool>
{
    public int UserId { get; set; }
}
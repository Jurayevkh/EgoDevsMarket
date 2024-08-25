using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Commands.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.User;

public class DeleteUserHandler : IRequestHandler<DeleteUser, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    public async Task<bool> Handle(DeleteUser request, CancellationToken cancellationToken)
    {
        try
        {
            var user=await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id==request.UserId);
            if (user==null)
                return false;
            _applicationDbContext.Users.Remove(user);
            var result=await _applicationDbContext.SaveChangesAsync(cancellationToken); 
            return result >0;
        }
        catch
        {
            return false;
        }
    }
}

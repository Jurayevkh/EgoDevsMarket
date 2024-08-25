using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Commands.User;
using EgoDevsMarket.Domain.Entities.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.User;

public class UpdateUserHandler : IRequestHandler<UpdateUser, Users>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateUserHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Users> Handle(UpdateUser request, CancellationToken cancellationToken)
    {
        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u=>u.Id == request.Id);
        if(request.FirstName !="" || request.FirstName != null)
            user.FirstName=request.FirstName;
        if(request.LastName !="" || request.LastName != null)
            user.LastName=request.LastName;
        if(request.BirthDate != null)
            user.BirthDate=request.BirthDate;
        if(request.Gender != "" ||request.Gender != null)
            user.Gender=request.Gender;
        if(request.Email !="" || request.Email != null)
            user.Email=request.Email;
        if(request.PhoneNumber !="" || request.PhoneNumber != null)
            user.PhoneNumber=request.PhoneNumber;
        if(request.Role != "" || request.Role != null)
            user.Role=request.Role;
        _applicationDbContext.Users.Update(user);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return user;
    }
}

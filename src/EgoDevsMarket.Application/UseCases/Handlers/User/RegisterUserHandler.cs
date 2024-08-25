using AutoMapper;
using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Commands.User;
using EgoDevsMarket.Domain.Entities.User;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Handlers.User;

public class RegisterUserHandler : IRequestHandler<RegisterUser, Users>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly Mapper _mapper;
    public RegisterUserHandler(IApplicationDbContext applicationDbContext, Mapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<Users> Handle(RegisterUser request, CancellationToken cancellationToken)
    {
        var user= _mapper.Map<Users>(request);
        user.CreatedAt = DateTimeOffset.UtcNow;
        await _applicationDbContext.Users.AddAsync(user);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return user;
    }

}

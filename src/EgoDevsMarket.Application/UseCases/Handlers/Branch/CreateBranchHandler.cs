using AutoMapper;
using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Commands.Branch;
using EgoDevsMarket.Domain.Entities.Branch;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Handlers.Branch;

public class CreateBranchHandler : IRequestHandler<CreateBranch, Branches>
{   
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly Mapper _mapper;

    public CreateBranchHandler(IApplicationDbContext applicationDbContext, Mapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<Branches> Handle(CreateBranch request, CancellationToken cancellationToken)
    {
        Branches branch = _mapper.Map<Branches>(request);
        await _applicationDbContext.Branches.AddAsync(branch);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return branch;
    }

}
using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Commands.Branch;
using EgoDevsMarket.Domain.Entities.Branch;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Handlers.Branch;

public class UpdateBranchHandler : IRequestHandler<UpdateBranch, Branches>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateBranchHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Branches> Handle(UpdateBranch request, CancellationToken cancellationToken)
    {
        Branches branch = _applicationDbContext.Branches.FirstOrDefault(b => b.Id==request.Id);
        if (request.Name != "")
            branch.Name = request.Name;
        if(request.Address !="")
            branch.Address = request.Address;
        _applicationDbContext.Branches.Update(branch);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return branch;
    }
}

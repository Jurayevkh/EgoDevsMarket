using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Commands.Branch;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Branch;

public class DeleteBranchHandler : IRequestHandler<DeleteBranch, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteBranchHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteBranch request, CancellationToken cancellationToken)
    {
        try
        {
            var branch = await _applicationDbContext.Branches.FirstOrDefaultAsync(b=>b.Id==request.BranchId);

            if(branch is null)
                return false;
            
            _applicationDbContext.Branches.Remove(branch);
            var result = await _applicationDbContext.SaveChangesAsync();
            return result>0;
        }
        catch{
            return false;
        }
    }
}
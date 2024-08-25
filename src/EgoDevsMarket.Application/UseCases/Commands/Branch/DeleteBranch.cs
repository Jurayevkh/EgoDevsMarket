using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.Branch;

public class DeleteBranch:IRequest<bool>
{
    public int BranchId{get;set;}
}
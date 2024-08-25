using EgoDevsMarket.Application.DTO.Branch;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.Branch;

public class CreateBranch:IRequest<BranchResultDTO>
{
    public string Name{get;set;}
    public string Address{get;set;}
}
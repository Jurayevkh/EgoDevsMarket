using EgoDevsMarket.Application.DTO.Branch;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.Branch;

public class UpdateBranch:IRequest<BranchResultDTO>
{
    public int Id{get;set;}
    public string? Name{get;set;}
    public string? Address{get;set;}
}
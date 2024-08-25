using EgoDevsMarket.Domain.Entities.Branch;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.Branch;

public class UpdateBranch:IRequest<Branches>
{
    public int Id{get;set;}
    public string? Name{get;set;}
    public string? Address{get;set;}
}
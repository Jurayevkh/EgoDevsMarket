using EgoDevsMarket.Domain.Entities.Branch;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.Branch;

public class CreateBranch:IRequest<Branches>
{
    public string Name{get;set;}
    public string Address{get;set;}
}
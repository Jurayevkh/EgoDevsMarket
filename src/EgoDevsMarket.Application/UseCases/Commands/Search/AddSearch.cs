using EgoDevsMarket.Domain.Entities.Search;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.Search;

public class AddSearch:IRequest<Searchs>
{
    public string Keyword{get;set;}
}
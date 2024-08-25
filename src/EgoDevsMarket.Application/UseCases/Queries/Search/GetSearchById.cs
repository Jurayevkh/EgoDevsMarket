using EgoDevsMarket.Domain.Entities.Search;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Queries.Search;

public class GetSearchById:IRequest<Searchs>{public int Id{get;set;}}
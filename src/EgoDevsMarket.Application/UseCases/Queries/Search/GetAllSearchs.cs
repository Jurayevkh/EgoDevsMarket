using EgoDevsMarket.Domain.Entities.Search;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Queries.Search;

public class GetAllSearchs:IRequest<List<Searchs>>{}
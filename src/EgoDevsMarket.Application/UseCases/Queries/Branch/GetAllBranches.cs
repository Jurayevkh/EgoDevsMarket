using EgoDevsMarket.Domain.Entities.Branch;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Queries.Branch;

public class GetAllBranches:IRequest<List<Branches>>{}
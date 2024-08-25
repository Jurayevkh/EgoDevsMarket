using EgoDevsMarket.Domain.Entities.User;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Queries.User;

public class GetAllUsers:IRequest<List<Users>>{}
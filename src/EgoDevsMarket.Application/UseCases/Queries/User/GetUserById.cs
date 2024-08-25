using EgoDevsMarket.Domain.Entities.User;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Queries.User;

public class GetUserById:IRequest<Users>{public int Id{get;set;}}
using EgoDevsMarket.Domain.Entities.Order;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Queries.Order;

public class GetOrderById:IRequest<Orders>{public int Id {get;set;}}
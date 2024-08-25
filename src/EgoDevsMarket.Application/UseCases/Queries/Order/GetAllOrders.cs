using EgoDevsMarket.Domain.Entities.Order;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Queries.Order;

public class GetAllOrders:IRequest<List<Orders>>{}
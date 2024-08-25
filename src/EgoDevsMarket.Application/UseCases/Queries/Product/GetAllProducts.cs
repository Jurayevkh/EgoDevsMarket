using EgoDevsMarket.Domain.Entities.Product;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Queries.Product;

public class GetAllProducts:IRequest<List<Products>>{}
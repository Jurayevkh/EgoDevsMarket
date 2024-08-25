using EgoDevsMarket.Domain.Entities.Product;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Queries.Product;

public class GetProductById:IRequest<Products>{public int Id{get;set;}}
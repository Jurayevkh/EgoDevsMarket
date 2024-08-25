using EgoDevsMarket.Domain.Entities.Category;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Queries.Category;

public class GetAllCategories : IRequest<List<Categories>>{} 
using EgoDevsMarket.Domain.Entities.Category;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Queries.Category;

public class GetCategoryById:IRequest<Categories>{public int Id{get;set;}}
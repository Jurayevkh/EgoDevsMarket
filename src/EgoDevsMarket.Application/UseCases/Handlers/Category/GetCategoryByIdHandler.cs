using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Queries.Category;
using EgoDevsMarket.Domain.Entities.Category;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Category;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryById, Categories>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetCategoryByIdHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Categories> Handle(GetCategoryById request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Categories.FirstOrDefaultAsync(c=>c.Id == request.Id);
    }
}

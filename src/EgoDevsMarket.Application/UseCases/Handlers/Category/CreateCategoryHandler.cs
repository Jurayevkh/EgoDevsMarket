using AutoMapper;
using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Commands.Category;
using EgoDevsMarket.Domain.Entities.Category;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Handlers.Category;

public class CreateCategoryHandler : IRequestHandler<CreateCategory, Categories>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly Mapper _mapper;
    public CreateCategoryHandler(IApplicationDbContext applicationDbContext, Mapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<Categories> Handle(CreateCategory request, CancellationToken cancellationToken)
    {
        Categories category = _mapper.Map<Categories>(request);
        await _applicationDbContext.Categories.AddAsync(category);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return category;
    }
}

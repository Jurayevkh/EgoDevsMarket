using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Commands.Category;
using EgoDevsMarket.Domain.Entities.Category;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Category;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategory, Categories>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateCategoryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Categories> Handle(UpdateCategory request, CancellationToken cancellationToken)
    {
        Categories category= await _applicationDbContext.Categories.FirstOrDefaultAsync(c=>c.Id==request.Id);
        if(request.Name != "")
            category.Name=request.Name;
        if(request.PhotoLink !="")
            category.PhotoLink=request.PhotoLink;
        _applicationDbContext.Categories.Update(category);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return category;
    }
}

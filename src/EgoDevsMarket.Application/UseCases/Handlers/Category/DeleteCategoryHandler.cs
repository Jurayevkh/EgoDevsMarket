using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Commands.Category;
using EgoDevsMarket.Domain.Entities.Category;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Handlers.Category;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategory, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteCategoryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteCategory request, CancellationToken cancellationToken)
    {
        try
        {   
            Categories category= _applicationDbContext.Categories.FirstOrDefault(c => c.Id==request.CategoryId);
            if (category is null)
                return false;
            _applicationDbContext.Categories.Remove(category);            
            var result=await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result>0;
        }
        catch
        {
            return false;
        }
    }

}

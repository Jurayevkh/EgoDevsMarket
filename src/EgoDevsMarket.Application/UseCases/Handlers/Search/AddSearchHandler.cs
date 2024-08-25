using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.UseCases.Commands.Search;
using EgoDevsMarket.Domain.Entities.Search;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Search;

public class AddSearchHandler : IRequestHandler<AddSearch, Searchs>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public AddSearchHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Searchs> Handle(AddSearch request, CancellationToken cancellationToken)
    {
        Searchs search= await _applicationDbContext.Searchs.FirstOrDefaultAsync(s=>s.Keyword==request.Keyword);
        if(search is not null)
        {
            search.Quantity+=1;
            _applicationDbContext.Searchs.Update(search);   
        }
        else
        {
            search.Keyword=request.Keyword;
            search.Quantity=1;
            await _applicationDbContext.Searchs.AddAsync(search);
        }
        await _applicationDbContext.SaveChangesAsync();
        return search;
    }
}

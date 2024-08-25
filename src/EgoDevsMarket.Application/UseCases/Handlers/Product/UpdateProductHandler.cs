using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.DTO.Product;
using EgoDevsMarket.Application.UseCases.Commands.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Product;

public class UpdateProductHandler : IRequestHandler<UpdateProduct, ProductResultDTO>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateProductHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<ProductResultDTO> Handle(UpdateProduct request, CancellationToken cancellationToken)
    {
        var product = await _applicationDbContext.Products.FirstOrDefaultAsync(p=>p.Id == request.Id);
        if(request.Name != "" || request.Name is not null)
            product.Name=request.Name;
        if(request.Price != null)
            product.Price=request.Price;
        if(request.CategoryId != null)
            product.CategoryId=request.CategoryId;
        if(request.Description !="" || request.Description is not null)
            product.Description=request.Description;
        if(request.PhotoLink !="" || request.PhotoLink is not null)
            product.PhotoLink=request.PhotoLink;
        product.UpdatedAt = DateTimeOffset.UtcNow;
        _applicationDbContext.Products.Update(product);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        var seller = await _applicationDbContext.Users.FirstOrDefaultAsync(s=>s.Id==product.SellerId);
        var category = await _applicationDbContext.Categories.FirstOrDefaultAsync(c=>c.Id==request.CategoryId);
        ProductResultDTO productResultDTO = new ProductResultDTO
        {
            Id=product.Id,
            Name=product.Name,
            Price=product.Price,
            CategoryName=category.Name,
            Description=product.Description,
            PhotoLink=product.PhotoLink,
            SoldQuantity=product.SoldQuantity,
            SellerId=seller.Id,
            SellerName=seller.FirstName+" "+seller.LastName,
            SellerEmail=seller.Email,
            SellerPhoneNumber=seller.PhoneNumber
        };
        return productResultDTO; 
    }
}
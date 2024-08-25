using AutoMapper;
using EgoDevsMarket.Application.Abstractions;
using EgoDevsMarket.Application.DTO.Product;
using EgoDevsMarket.Application.UseCases.Commands.Product;
using EgoDevsMarket.Domain.Entities.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.UseCases.Handlers.Product;

public class CreateProductHandler : IRequestHandler<CreateProduct, ProductResultDTO>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly Mapper _mapper;

    public CreateProductHandler(Mapper mapper, IApplicationDbContext applicationDbContext)
    {
        _mapper = mapper;
        _applicationDbContext = applicationDbContext;
    }
    public async Task<ProductResultDTO> Handle(CreateProduct request, CancellationToken cancellationToken)
    {
        Products product= _mapper.Map<Products>(request);
        product.CreatedAt = DateTimeOffset.UtcNow;
        product.SoldQuantity=0;
        await _applicationDbContext.Products.AddAsync(product);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        var seller = await _applicationDbContext.Users.FirstOrDefaultAsync(s=>s.Id==request.SellerId);
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

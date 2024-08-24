namespace EgoDevsMarket.Domain.Entities.Product;

public class Products : BaseEntity
{
    public string Name{get;set;}
    public decimal Price{get;set;}
    public string Description{get;set;}
    public string PhotoLink{get;set;}
    public int CategoryId{get;set;}
    public int SellerId{get;set;}
    public int SoldQuantity{get;set;}=0;
    public DateTimeOffset CreatedAt{get;set;}
    public DateTimeOffset UpdatedAt{get;set;}
}
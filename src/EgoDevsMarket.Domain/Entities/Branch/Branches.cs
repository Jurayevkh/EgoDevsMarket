namespace EgoDevsMarket.Domain.Entities.Branch;

public class Branches : BaseEntity
{
    public string Name{get;set;}
    public string Address{get;set;}
    public int OrderQuantity{get;set;}=0;
}
namespace EgoDevsMarket.Domain.Entities.Branch;

public class Branch : BaseEntity
{
    public string Name{get;set;}
    public int OrderQuantity{get;set;}=0;
}
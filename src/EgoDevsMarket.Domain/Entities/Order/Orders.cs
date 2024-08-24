namespace EgoDevsMarket.Domain.Entities.Order;

public class Orders:BaseEntity
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int BranchId{get;set;}
    public DateTimeOffset CreatedAt{get;set;}
}

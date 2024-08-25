namespace EgoDevsMarket.Application.DTO.Order;

public class OrderResultDTO
{
    public int Id {get;set;}

    public int UserId {get;set;}
    public string FullName{get;set;}

    public int SellerId{get;set;}
    public string SellerName{get;set;}

    public int ProductId{get;set;}
    public string ProductName{get;set;}
    public decimal ProductPrice{get;set;}

   public int BranchId{get;set;}
   public string BranchName{get;set;}
   public string BranchAddress{get;set;}
}

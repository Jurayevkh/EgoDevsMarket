namespace EgoDevsMarket.Domain.Entities.Search;
public class Searchs:BaseEntity
{
    public string Keyword{get; set;}
    public int Quantity{get;set;}=0; 
}
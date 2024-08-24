using EgoDevsMarket.Domain.Entities.Branch;
using EgoDevsMarket.Domain.Entities.Category;
using EgoDevsMarket.Domain.Entities.Order;
using EgoDevsMarket.Domain.Entities.Product;
using EgoDevsMarket.Domain.Entities.Search;
using EgoDevsMarket.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace EgoDevsMarket.Application.Abstractions;

public interface IApplicationDbContext
{
    public DbSet<Users> Users { get; set; }
    public DbSet<Categories> Categories{get;set;}
    public DbSet<Products> Products {get;set;}
    public DbSet<Branches> Branches{get;set;}
    public DbSet<Orders> Orders{get;set;}
    public DbSet<Searchs> Searchs{get;set;} 

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);
}
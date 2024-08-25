using AutoMapper;
using EgoDevsMarket.Application.UseCases.Commands.Branch;
using EgoDevsMarket.Application.UseCases.Commands.Category;
using EgoDevsMarket.Application.UseCases.Commands.Order;
using EgoDevsMarket.Application.UseCases.Commands.Product;
using EgoDevsMarket.Application.UseCases.Commands.Search;
using EgoDevsMarket.Application.UseCases.Commands.User;
using EgoDevsMarket.Domain.Entities.Branch;
using EgoDevsMarket.Domain.Entities.Category;
using EgoDevsMarket.Domain.Entities.Order;
using EgoDevsMarket.Domain.Entities.Product;
using EgoDevsMarket.Domain.Entities.Search;
using EgoDevsMarket.Domain.Entities.User;

namespace EgoDevsMarket.Application;

public class MappingConfigurations:Profile
{
    public MappingConfigurations()
    {
        CreateMap<CreateBranch, Branches>().ReverseMap();
        CreateMap<CreateCategory, Categories>().ReverseMap();
        CreateMap<CreateOrder, Orders>().ReverseMap();
        CreateMap<CreateProduct, Products>().ReverseMap();
        CreateMap<AddSearch, Searchs>().ReverseMap();
        CreateMap<RegisterUser, Users>().ReverseMap();
    }
}

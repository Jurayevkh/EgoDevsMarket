using EgoDevsMarket.API.Helpers;
using EgoDevsMarket.Application.UseCases.Commands.Product;
using EgoDevsMarket.Application.UseCases.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EgoDevsMarket.API.Controller;


[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController:ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllProducts()
        => Ok(new Response
        { StatusCode=200,
          Message="Success",
          Data=await _mediator.Send(new GetAllProducts())
        });

    [HttpGet]
    public async ValueTask<IActionResult> GetProductById(int Id)
        => Ok(new Response
        {
            StatusCode=200,
            Message="Success",
            Data = await _mediator.Send(new GetProductById() {Id=Id})
        });

    [HttpPost]
    public async ValueTask<IActionResult> CreateProduct([FromForm]CreateProduct product)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(product)
        });

    [HttpPut]
    public async ValueTask<IActionResult> UpdateProduct([FromForm]UpdateProduct product)
        => Ok(new Response
        {
            StatusCode=200,
            Message="Success",
            Data = await _mediator.Send(product)
        });

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteProduct(int Id)
        => Ok(new Response
        {
            StatusCode=200,
            Message="Success",
            Data = await _mediator.Send(new DeleteProduct() {ProductId=Id})
        });
}

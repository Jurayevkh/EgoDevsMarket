using EgoDevsMarket.API.Helpers;
using EgoDevsMarket.Application.UseCases.Commands.Order;
using EgoDevsMarket.Application.UseCases.Queries.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EgoDevsMarket.API.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
public class OrderController:ControllerBase
{
     private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllOrders()
        => Ok(new Response
        { StatusCode=200,
          Message="Success",
          Data=await _mediator.Send(new GetAllOrders())
        });

    [HttpGet]
    public async ValueTask<IActionResult> GetOrderById(int Id)
        => Ok(new Response
        {
            StatusCode=200,
            Message="Success",
            Data = await _mediator.Send(new GetOrderById() {Id=Id})
        });

    [HttpPost]
    public async ValueTask<IActionResult> CreateOrder([FromForm]CreateOrder order)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(order)
        });
}

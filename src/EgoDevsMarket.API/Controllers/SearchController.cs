using EgoDevsMarket.API.Helpers;
using EgoDevsMarket.Application.UseCases.Commands.Search;
using EgoDevsMarket.Application.UseCases.Queries.Search;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EgoDevsMarket.API.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
public class SearchController:ControllerBase
{
    private readonly IMediator _mediator;

    public SearchController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllSearchs()
        => Ok(new Response
        { StatusCode=200,
          Message="Success",
          Data=await _mediator.Send(new GetAllSearchs())
        });

    [HttpGet]
    public async ValueTask<IActionResult> GetSearchById(int Id)
        => Ok(new Response
        {
            StatusCode=200,
            Message="Success",
            Data = await _mediator.Send(new GetSearchById() {Id=Id})
        });

    [HttpPost]
    public async ValueTask<IActionResult> AddSearch([FromForm]AddSearch search)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(search)
        });
}

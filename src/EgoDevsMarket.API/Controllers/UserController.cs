using EgoDevsMarket.API.Helpers;
using EgoDevsMarket.Application.UseCases.Commands.User;
using EgoDevsMarket.Application.UseCases.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EgoDevsMarket.API.Controller;


[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllUsers()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(new GetAllUsers())
        });

    [HttpGet]
    public async ValueTask<IActionResult> GetUserById(int Id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(new GetUserById() { Id = Id })
        });

    [HttpPost]
    public async ValueTask<IActionResult> RegisterUser([FromForm] RegisterUser user)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(user)
        });

    [HttpPut]
    public async ValueTask<IActionResult> UpdateUser([FromForm] UpdateUser user)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(user)
        });

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteUser(int Id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(new DeleteUser() { UserId = Id })
        });
}

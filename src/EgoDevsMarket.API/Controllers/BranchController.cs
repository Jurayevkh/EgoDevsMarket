using EgoDevsMarket.API.Helpers;
using EgoDevsMarket.Application.UseCases.Commands.Branch;
using EgoDevsMarket.Application.UseCases.Queries.Branch;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EgoDevsMarket.API.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
public class BranchController:ControllerBase
{
    private readonly IMediator _mediator;

    public BranchController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllBranches()
        => Ok(new Response
        { StatusCode=200,
          Message="Success",
          Data=await _mediator.Send(new GetAllBranches())
        });

    [HttpGet]
    public async ValueTask<IActionResult> GetBranchById(int Id)
        => Ok(new Response
        {
            StatusCode=200,
            Message="Success",
            Data = await _mediator.Send(new GetBranchById() {Id=Id})
        });

    [HttpPost]
    public async ValueTask<IActionResult> CreateBranch([FromForm]CreateBranch branch)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(branch)
        });

    [HttpPut]
    public async ValueTask<IActionResult> UpdateRecruiter([FromForm]UpdateBranch branch)
        => Ok(new Response
        {
            StatusCode=200,
            Message="Success",
            Data = await _mediator.Send(branch)
        });

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteBranch(int Id)
        => Ok(new Response
        {
            StatusCode=200,
            Message="Success",
            Data = await _mediator.Send(new DeleteBranch() {BranchId=Id})
        });
}

using EgoDevsMarket.API.Helpers;
using EgoDevsMarket.Application.UseCases.Commands.Category;
using EgoDevsMarket.Application.UseCases.Queries.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EgoDevsMarket.API.Controller;


[Route("api/[controller]/[action]")]
[ApiController]
public class CategoryController:ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllCategories()
        => Ok(new Response
        { StatusCode=200,
          Message="Success",
          Data=await _mediator.Send(new GetAllCategories())
        });

    [HttpGet]
    public async ValueTask<IActionResult> GetCategoryById(int Id)
        => Ok(new Response
        {
            StatusCode=200,
            Message="Success",
            Data = await _mediator.Send(new GetCategoryById() {Id=Id})
        });

    [HttpPost]
    public async ValueTask<IActionResult> CreateCategory([FromForm]CreateCategory category)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(category)
        });

    [HttpPut]
    public async ValueTask<IActionResult> UpdateCategory([FromForm]UpdateCategory category)
        => Ok(new Response
        {
            StatusCode=200,
            Message="Success",
            Data = await _mediator.Send(category)
        });

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteCategory(int Id)
        => Ok(new Response
        {
            StatusCode=200,
            Message="Success",
            Data = await _mediator.Send(new DeleteCategory() {CategoryId=Id})
        });
}

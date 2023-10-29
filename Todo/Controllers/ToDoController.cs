using Microsoft.AspNetCore.Mvc;
using ToDo.Models.Dtos;
using ToDo.Services;

namespace ToDo.Controllers;

[ApiController]
[Route("/api/todo")]
public class ToDoController : ControllerBase
{
    private readonly ITodoService _todoService;
    
    public ToDoController(ITodoService todoService)
    {
        _todoService = todoService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ToDoCreateDto model)
    {
        var result = await _todoService.CreateAsync(model);
        return Created(new Uri($"/api/todo/{result.Id}", UriKind.Relative), result);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _todoService.GetAsync();
        return result.Count != 0
            ? Ok(result)
            : NoContent();
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await _todoService.GetAsync(id);
        return result is null
            ? NotFound()
            : Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ToDoUpdateDto model)
    {
        await _todoService.UpdateAsync(model);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _todoService.DeleteAsync(id);
        return Ok();
    }
}

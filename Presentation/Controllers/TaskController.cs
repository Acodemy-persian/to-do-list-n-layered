using System;
using Application.DTOs.Task;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filters;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[HandleServiceResult]
public class TaskController(ITaskService taskService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add(TaskAddCommandModel taskAddCommandModel)
    {
        var result = await taskService.AddAsync(taskAddCommandModel);
        return CreatedAtAction(nameof(GetById), new {id = result.Data}, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await taskService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await taskService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveById(Guid id)
    {
        var result = await taskService.RemoveByIdAsync(id);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(TaskUpdateCommandModel taskUpdateCommandModel)
    {
        var result = await taskService.UpdateAsync(taskUpdateCommandModel);
        return Ok(result);
    }
}

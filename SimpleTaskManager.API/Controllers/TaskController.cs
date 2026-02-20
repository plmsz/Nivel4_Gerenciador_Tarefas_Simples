using Microsoft.AspNetCore.Mvc;
using SimpleTaskManager.Application.UseCases.Task;
using SimpleTaskManager.Communication.Repository;
using SimpleTaskManager.Communication.Responses;

namespace SimpleTaskManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly TaskService _taskService;
    private readonly Repository _repository;

    public TaskController(TaskService taskService, Repository repository)
    {
        _taskService = taskService;
        _repository = repository;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllTasksJson), 200)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Get()
    {
        var useCase = new GetAllTasks(_repository);
        var response = useCase.Execute();

        if (response.Count != 0)
        {
            return Ok(response);
        }
        return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(Guid id)
    {
        var useCase = new GetByIdTask(_repository);
        var response = useCase.Execute(id);

        if (response is not null)
        {
            return Ok(response);
        }
        return NotFound();
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseTaskJson), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post([FromBody] RequestTaskJson payload)
    {
        try
        {
            _taskService.ValidateTask(payload);

            var useCase = new PostTask(_repository);
            var response = useCase.Execute(payload);

            if (response is not null)
            {
                return Created(string.Empty, response);
            }
            return BadRequest();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [ProducesResponseType(typeof(ResponseTaskJson), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] RequestTaskJson payload)
    {
        try
        {
            _taskService.ValidateTask(payload);

            var useCase = new UpdateTask(_repository);
            var response = useCase.Execute(id, payload);

            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        catch (InvalidOperationException e)
        {
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            var useCase = new DeleteTask(_repository);
            useCase.Execute(id);

            return NoContent();
        }
        catch (InvalidOperationException e)
        {
            return NotFound();
        }
    }
}
using SimpleTaskManager.Communication.Repository;
using SimpleTaskManager.Communication.Responses;

namespace SimpleTaskManager.Application.UseCases.Task;

public class PostTask
{
    private readonly Repository _repository;

    public PostTask(Repository repository)
    {
        _repository = repository;
    }

    public Communication.Entity.Task Execute(RequestTaskJson payload)
    {
        var task = new Communication.Entity.Task
        {
            Id = Guid.NewGuid(),
            Description = payload.Description,
            DueDate = payload.DueDate,
            Name = payload.Name,
            Priority = payload.Priority,
            Status = payload.Status,
        };

        _repository.TaskList.Add(task);

        return task;
    }
}
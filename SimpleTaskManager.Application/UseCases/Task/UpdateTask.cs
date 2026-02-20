using SimpleTaskManager.Communication.Repository;
using SimpleTaskManager.Communication.Responses;

namespace SimpleTaskManager.Application.UseCases.Task;

public class UpdateTask
{
    private readonly Repository _repository;

    public UpdateTask(Repository repository)
    {
        _repository = repository;
    }

    public Communication.Entity.Task Execute(Guid id, RequestTaskJson payload)
    {
        var task = _repository.TaskList.Find(task => task.Id == id);

        if (task is null)
        {
            throw new InvalidOperationException("Task was not found");
        }

        _repository.TaskList.Remove(task);

        var updatedTask = new Communication.Entity.Task
        {
            Id = id,
            Name = payload.Name,
            Description = payload.Description,
            DueDate = payload.DueDate,
            Priority = payload.Priority,
            Status = payload.Status
        };

        _repository.TaskList.Add(updatedTask);

        return updatedTask;
    }
}
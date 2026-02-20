using SimpleTaskManager.Communication.Repository;

namespace SimpleTaskManager.Application.UseCases.Task;

public class DeleteTask
{
    private readonly Repository _repository;

    public DeleteTask(Repository repository)
    {
        _repository = repository;
    }

    public void Execute(Guid id)
    {
        var task = _repository.TaskList.Find(task => task.Id == id);

        if (task is null)
        {
            throw new InvalidOperationException("Task was not found");
        }

        _repository.TaskList.Remove(task);
    }
}
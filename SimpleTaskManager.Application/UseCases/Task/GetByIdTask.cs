using SimpleTaskManager.Communication.Repository;

namespace SimpleTaskManager.Application.UseCases.Task;

public class GetByIdTask
{
    private readonly Repository _repository;

    public GetByIdTask(Repository repository)
    {
        _repository = repository;
    }

    public Communication.Entity.Task Execute(Guid id)
    {
        var task = _repository.TaskList.Find(task => task.Id == id);

        return task;
    }
}
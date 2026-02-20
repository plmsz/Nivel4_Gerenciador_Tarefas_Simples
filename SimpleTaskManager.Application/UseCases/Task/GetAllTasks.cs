using SimpleTaskManager.Communication.Repository;

namespace SimpleTaskManager.Application.UseCases.Task;

public class GetAllTasks
{
    private readonly Repository _repository;

    public GetAllTasks(Repository repository)
    {
        _repository = repository;
    }

    public List<Communication.Entity.Task> Execute()
    {
        return _repository.TaskList.ToList();
    }
}
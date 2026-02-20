namespace SimpleTaskManager.Communication.Repository;

using SimpleTaskManager.Communication.Entity;
using SimpleTaskManager.Communication.Enum;

public class Repository
{
    public List<Task> TaskList { get; } = [];

    public Repository()
    {
        TaskList.Add(new Task
        {
            Description = "",
            DueDate = new DateTime(2025, 01, 30, 08, 09, 0),
            Id = Guid.NewGuid(),
            Name = "Lavar roupas",
            Priority = Priority.Medium,
            Status = Status.Pending,
        });
    }
}
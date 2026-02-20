using SimpleTaskManager.Communication.Enum;

namespace SimpleTaskManager.Communication.Entity;

public class Task
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public DateTime DueDate { get; set; }
}
namespace SimpleTaskManager.Communication.Responses;

public class ResponseAllTasksJson
{
    public List<Entity.Task> AllTasks { get; set; } = [];
}
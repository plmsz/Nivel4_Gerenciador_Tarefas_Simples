using SimpleTaskManager.Communication.Enum;

namespace SimpleTaskManager.Communication.Responses;

public class ResponseTaskJson
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public DateTime DueDate { get; set; }
}
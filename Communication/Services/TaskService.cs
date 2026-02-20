namespace SimpleTaskManager.Communication.Repository;

using SimpleTaskManager.Communication.Enum;
using SimpleTaskManager.Communication.Requests;
using System;

public class TaskService
{
    public void ValidateTask(RequestTaskJson task, bool isCreation = false)
    {
        if (String.IsNullOrEmpty(task.Name))
        {
            throw new ArgumentException("Name is required");
        }
        if (task.Name.Length > 100)
        {
            throw new ArgumentException("Length must be less than 100 char");
        }
        if (task.Description?.Length > 500)
        {
            throw new ArgumentException("Description must be less than 500 characters");
        }
        var validStatus = Enum.IsDefined(typeof(Status), task.Status);
        if (!validStatus)
        {
            throw new ArgumentException("Status is invalid.");
        }

        var validPriority = Enum.IsDefined(typeof(Priority), task.Priority);
        if (!validPriority)
        {
            throw new ArgumentException("Priority is invalid.");
        }
        if (isCreation && task.DueDate <= DateTime.Now)
        {
            throw new ArgumentException("Date must be greater than now");
        }
    }
}
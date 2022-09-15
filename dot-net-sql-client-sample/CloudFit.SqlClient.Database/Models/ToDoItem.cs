namespace CloudFit.SqlClient.Database.Models;

public class ToDoItem
{
    public ToDoItem(int taskId, string taskName, string assignedTo)
    {
        TaskId = taskId;
        TaskName = taskName;
        AssignedTo = assignedTo;
    }

    public int TaskId { get; }
    public string TaskName { get; }
    public string AssignedTo { get; }

    public override string ToString()
    {
        return $"{nameof(TaskId)}: {TaskId}, {nameof(TaskName)}: {TaskName}, {nameof(AssignedTo)}: {AssignedTo}";
    }
}
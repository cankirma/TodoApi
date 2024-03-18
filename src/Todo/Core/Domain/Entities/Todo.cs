namespace Domain.Entities;

public class Todo:BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public TodoStatus Status { get; set; }
}

public enum TodoStatus
{
    Waiting,
    InProgress,
    Completed
}

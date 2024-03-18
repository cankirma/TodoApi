namespace Application.Contracts.Todo;

public record TodoItem
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Status { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime  UpdatedTime { get; set; }
}

public record CreateTodoItemContract
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Status { get; set; }

}

public record UpdateTodoItemContract(string Id, string Title, string Content, string status);
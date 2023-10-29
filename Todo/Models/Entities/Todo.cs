namespace ToDo.Models.Entities;

public sealed class Todo
{
    public Guid Id { get; set; }
    
    public required string Description { get; init; }
    
    public required bool IsChecked { get; init; }
}

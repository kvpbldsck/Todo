namespace ToDo.Models.Dtos;

public sealed record ToDoReadDto(Guid Id, string Description, bool IsChecked);

using System.Text.Json.Serialization;

namespace ToDo.Models.Dtos;

public sealed record ToDoUpdateDto(Guid Id, string Description, bool IsChecked);

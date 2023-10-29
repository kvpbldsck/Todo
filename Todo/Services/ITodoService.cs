using ToDo.Models.Dtos;

namespace ToDo.Services;

public interface ITodoService
{
    Task<ToDoReadDto> CreateAsync(ToDoCreateDto model);
    Task<ToDoReadDto?> GetAsync(Guid id);
    Task<IReadOnlyCollection<ToDoReadDto>> GetAsync();
    Task UpdateAsync(ToDoUpdateDto model);
    Task DeleteAsync(Guid id);
}

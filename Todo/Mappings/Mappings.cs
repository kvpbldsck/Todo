using ToDo.Models.Dtos;
using ToDo.Models.Entities;

namespace ToDo.Mappings;

public static class Mappings
{
    public static Todo ToEntity(this ToDoCreateDto model)
    {
        return new Todo
        {
            Id = Guid.NewGuid(),
            IsChecked = false,
            Description = model.Description
        };
    }
    public static Todo ToEntity(this ToDoUpdateDto model)
    {
        return new Todo
        {
            Id = model.Id,
            IsChecked = model.IsChecked,
            Description = model.Description
        };
    }

    public static ToDoReadDto ToDto(this Todo entity)
    {
        return new ToDoReadDto(
            entity.Id, 
            entity.Description, 
            entity.IsChecked);
    }
}

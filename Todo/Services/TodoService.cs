using Microsoft.EntityFrameworkCore;
using ToDo.Database;
using ToDo.Mappings;
using ToDo.Models.Dtos;
using ToDo.Models.Entities;

namespace ToDo.Services;

public sealed class TodoService: ITodoService
{
    private readonly AppDbContext _dbContext;

    public TodoService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ToDoReadDto> CreateAsync(ToDoCreateDto model)
    {
        var entity = model.ToEntity();
        
        _dbContext.Todos.Add(entity);

        await _dbContext.SaveChangesAsync();

        return entity.ToDto();
    }

    public async Task<ToDoReadDto?> GetAsync(Guid id)
    {
        var entity = await _dbContext.Todos
            .AsNoTracking()
            .SingleOrDefaultAsync(t => t.Id == id);;

        return entity?.ToDto();
    }

    public async Task<IReadOnlyCollection<ToDoReadDto>> GetAsync()
    {
        return await _dbContext.Todos
            .AsNoTracking()
            .Select(t => t.ToDto())
            .ToArrayAsync();
    }

    public async Task UpdateAsync(ToDoUpdateDto model)
    {
        if (!await _dbContext.Todos.AsNoTracking().AnyAsync(t => t.Id == model.Id))
        {
            throw new Exception($"Todo #{model.Id} not found");
        }
        
        _dbContext.Todos.Update(model.ToEntity());
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbContext.Todos
            .SingleOrDefaultAsync(t => t.Id == id);
        
        if (entity is null)
        {
            throw new Exception($"Todo #{id} not found");
        }

        _dbContext.Todos.Remove(entity);

        await _dbContext.SaveChangesAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using ToDo.Models.Entities;

namespace ToDo.Database;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
}

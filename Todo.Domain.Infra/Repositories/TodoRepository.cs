using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;
namespace Todo.Domain.Infra.Repositories;
public class TodoRepository : ITodoRepository
{
    private readonly DataContext _context;
    public TodoRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<TodoItem> Create(TodoItem todo)
    {
        var entity = await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
        return entity.Entity;
    }

    public async Task<IEnumerable<TodoItem>> GetAll(string user)
        => await _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAll(user))
            .OrderBy(x => x.StartDate)
            .ToListAsync();


    public  async Task<IEnumerable<TodoItem>> GetAllDone(string user)
        => await _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAllDone(user))
            .OrderBy(x => x.StartDate)
            .ToListAsync();
    

    public async Task<IEnumerable<TodoItem>> GetAllUndone(string user)
        => await _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAllUndone(user))
            .OrderBy(x => x.StartDate)
            .ToListAsync();
    

    public async Task<TodoItem> GetById(Guid? id, string? user)
        => await _context.Todos.FirstOrDefaultAsync(x => x.Id == id && x.User == user);
    

    public async Task<IEnumerable<TodoItem>> GetByPeriod(string? user, DateTime? date, bool? done)
        => await _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetByPeriod(user, date, done))
            .OrderBy(x => x.StartDate)
            .ToListAsync();
        

    public async Task<TodoItem> Update(TodoItem todo)
    {
        var result = _context.Update(todo);
        await _context.SaveChangesAsync();
        return result.Entity;
    }   
}

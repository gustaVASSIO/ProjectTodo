using Microsoft.EntityFrameworkCore;
using ProjectTodo.Context;
using ProjectTodo.Models.Entities;
using ProjectTodo.Models.Enums;
using ProjectTodo.Repository.Interfaces;

namespace ProjectTodo.Repository.Classes
{
    public class TodoRepository : Repository<Todo>, ITodoRepository
    {
        public TodoRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Todo> GetTodosNotConcluedOrderByDate()
        {
            return _context.Todos
                .AsNoTracking()
                .Where(t => t.State == TodoState.PENDING)
                .OrderBy(t => t.DateConclusion);

        }
    }
}

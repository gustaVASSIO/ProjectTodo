using ProjectTodo.Models.Entities;

namespace ProjectTodo.Repository.Interfaces
{
    public interface ITodoRepository : IRepository<Todo>
    {
        IEnumerable<Todo> GetTodosNotConcluedOrderByDate();
    }
}

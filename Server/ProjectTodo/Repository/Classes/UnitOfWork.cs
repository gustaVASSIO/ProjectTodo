using ProjectTodo.Context;
using ProjectTodo.Repository.Interfaces;

namespace ProjectTodo.Repository.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private TodoRepository todoRepo;
        protected AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ITodoRepository TodoRepository
        {
            get => todoRepo ?? new TodoRepository(_context);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

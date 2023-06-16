namespace ProjectTodo.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public ITodoRepository TodoRepository { get;  }
        Task Commit();
        void Dispose();
    }
}

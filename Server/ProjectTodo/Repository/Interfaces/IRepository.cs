namespace ProjectTodo.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        Task<T> GetById(string id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

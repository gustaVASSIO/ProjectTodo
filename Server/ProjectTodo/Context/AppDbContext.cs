using Microsoft.EntityFrameworkCore;
using ProjectTodo.Models.Entities;

namespace ProjectTodo.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
    }
}

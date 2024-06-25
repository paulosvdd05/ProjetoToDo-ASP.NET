using Microsoft.EntityFrameworkCore;
using ToDoAPI.Model;

namespace ToDoAPI.Infraestrutura.Repositories
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=todo_sample;User Id=postgres;Password=1234");
        }

    }
}

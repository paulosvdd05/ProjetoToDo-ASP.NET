using Microsoft.EntityFrameworkCore;
using ToDoAPI.Model;

namespace ToDoAPI.Infraestrutura.Repositories
{
    public class ConnectionContext : DbContext
    {

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {
        }

        public DbSet<Tasks> Tasks { get; set; }

    

        

    }
}

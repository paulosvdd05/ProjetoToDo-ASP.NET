using Microsoft.EntityFrameworkCore;
using ToDoAPI.Model;
using ToDoAPI.Models;

namespace ToDoAPI.Infraestrutura.Repositories
{
    public class ConnectionContext : DbContext
    {

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {
        }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
                .HasOne(t => t.Usuario)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UsuarioId);

            base.OnModelCreating(modelBuilder);
        }




    }
}

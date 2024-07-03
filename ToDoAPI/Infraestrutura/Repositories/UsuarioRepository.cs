using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using ToDoAPI.Interfaces;
using ToDoAPI.Models;

namespace ToDoAPI.Infraestrutura.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConnectionContext _context;
        public UsuarioRepository(ConnectionContext context)
        {
            _context = context;
        }

        public void add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
       


        public void delete(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public void deleteUsuario(int id)
        {
            var usuario = get(id);
            delete(usuario);
        }
        public Usuario get(int id) {
                        return _context.Usuarios.Find(id);
        }

        public Usuario get(string email)
        {
            return _context.Usuarios.FirstOrDefault(x => x.email == email);
        }


        public List<Usuario> Get(int pageNumber, int pageQuantity)
        {
            return _context.Usuarios.Skip(pageNumber * pageQuantity).Take(pageQuantity).OrderBy(x => x.id).ToList();
        }

        public List<Usuario> GetAll() {
                        return _context.Usuarios.ToList();
        }

        public void update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }
    }
}

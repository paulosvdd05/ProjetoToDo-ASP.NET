using ToDoAPI.Models;

namespace ToDoAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        void add(Usuario usuario);
        
        void delete(Usuario usuario);

        void update(Usuario usuario);

        void deleteUsuario(int id);

        List<Usuario> Get(int pageNumber, int pageQuantity);
        Usuario get(int id);

        Usuario get(string email);
    }
}

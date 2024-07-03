using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Interfaces;

namespace ToDoAPI.Controllers
{
    public class UsuariosViewController : Controller
    {
        private readonly IUsuarioRepository _usuariosRepository;

        public UsuariosViewController(IUsuarioRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public IActionResult Index()
        {
            var usuarios = _usuariosRepository.Get(0, 10); // Busca as primeiras 10 tarefas
            return View(usuarios);
        }

    }
}

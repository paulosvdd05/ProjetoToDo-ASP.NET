using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.DTOs;
using ToDoAPI.Infraestrutura.Repositories;
using ToDoAPI.Interfaces;
using ToDoAPI.Models;
using ToDoAPI.Services;
using ToDoAPI.ViewModel;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuariosRepository;
        private readonly ConnectionContext _context;


        public UsuariosController(IUsuarioRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository ?? throw new ArgumentNullException(nameof(usuariosRepository));

        
        }

        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            return Ok(_usuariosRepository.Get(pageNumber, pageQuantity));
        }
       
        [HttpPost]
  
        public IActionResult Cadastrar([FromBody] UsuarioViewModel usuario)
        {
            var usuarioCriptografia = new UsuarioCriptografia();
            byte[] salt = new byte[128 / 8];
            // Gerar o salt primeiro
            usuarioCriptografia.GeraSalt(salt);
            // Usar o salt gerado para criptografar a senha
            string senhaCriptografada = usuarioCriptografia.CriptografarSenha(usuario.Senha, salt);
            var usuarios = new Usuario(usuario.Nome, usuario.Email, senhaCriptografada, salt);
            _usuariosRepository.add(usuarios);
            return Ok();
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioLoginDTO usuario)
        {
            var usuarioBanco = _usuariosRepository.get(usuario.Email);

            if (usuarioBanco == null)
            {
                return NotFound("Usuário não encontrado");
            }

            var usuarioCriptografia = new UsuarioCriptografia();
            string senhaCriptografada = usuarioCriptografia.CriptografarSenha(usuario.Senha, usuarioBanco.salt);

            if (senhaCriptografada != usuarioBanco.senha)
            {
                return Unauthorized("Senha incorreta.");
            }

            var token = TokenService.GenerateToken(usuarioBanco);
            return Ok(token); // Retornando o token gerado
        }







        [HttpDelete]
        public IActionResult Delete([FromBody] Usuario usuario)
        {
            _usuariosRepository.delete(usuario);
            return Ok();
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoAPI.Model;

namespace ToDoAPI.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        public int id { get; private set; }
        public string nome { get; private set; }
        public string email { get; private set; }
        public string senha { get; private set; }
        public byte[] salt { get; private set; }

        public ICollection<Tasks> Tasks { get; set; }

        public Usuario() { }

        public Usuario(string nome, string email, string senha, byte[] salt)
        {
            this.nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.email = email;
            this.senha = senha;
            this.salt = salt;
        }
    }
}

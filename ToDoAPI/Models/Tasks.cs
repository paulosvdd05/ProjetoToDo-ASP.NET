

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoAPI.Models;

namespace ToDoAPI.Model
{
    [Table("tasks")]
    public class Tasks
    {
        [Key]

        public int id { get; private set; }
        public string title { get; private set; }

        public string description { get; private set; }

        public bool? iscompleted { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime DueDate { get; private set; }

        public int? Priority { get; private set; }

   
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        public Tasks() {
            
        }
        public Tasks(string title, string description, bool? iscompleted, DateTime CreatedDate, DateTime DueDate, int? Priority, int usuarioId)
        {
            this.title = title;
            this.description = description;
            this.iscompleted = iscompleted;
            this.CreatedDate = CreatedDate;
            this.DueDate = DueDate;
            this.Priority = Priority;
            this.UsuarioId = usuarioId;
        }

        public void MarkAsCompleted()
        {
            this.iscompleted = true;
            this.DueDate = DateTime.UtcNow;
        }


    }
}

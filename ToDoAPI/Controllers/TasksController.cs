using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoAPI.Interfaces;
using ToDoAPI.Model;
using ToDoAPI.ViewModel;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITasksRepository _tasksRepository;
        private readonly ILogger<TasksController> _logger;

        public TasksController(ITasksRepository tasksRepository, ILogger<TasksController> logger)
        {
            _tasksRepository = tasksRepository ?? throw new ArgumentNullException(nameof(tasksRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            var tasks = _tasksRepository.Get(pageNumber, pageQuantity)
                .Where(t => t.UsuarioId == int.Parse(User.FindFirst("usuarioId")?.Value))
                .Select(t => new TasksViewModel
                {
                    id = t.id,
                    title = t.title,
                    description = t.description,
                    iscompleted = t.iscompleted,
                    CreatedDate = t.CreatedDate,
                    DueDate = t.DueDate,
                    Priority = t.Priority
                })
                .ToList();

            return Ok(tasks);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           
            return Ok(_tasksRepository.get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] TasksViewModel tasksView)
        {
            var userIdString = User.FindFirst("usuarioId")?.Value;
            if (userIdString == null || !int.TryParse(userIdString, out int userId))
            {
                _logger.LogError("UserIdString = " + userIdString);
                return Unauthorized(); // Retorna um status 401 Unauthorized se não conseguir obter o ID do usuário ou não conseguir convertê-lo para int
            }

            var tasks = new Tasks(tasksView.title, tasksView.description, tasksView.iscompleted, tasksView.CreatedDate, tasksView.DueDate, tasksView.Priority, userId);
            _tasksRepository.add(tasks);
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult MarkAsCompleted(int id)
        {
            var task = _tasksRepository.get(id);
            if (task == null)
            {
                return NotFound();
            }

            _tasksRepository.MarkTaskAsCompleted(id);
            return NoContent(); // Retorna um status 204 No Content para indicar sucesso sem enviar uma resposta de corpo
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Tasks task)
        {
            _tasksRepository.delete(task);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            _tasksRepository.deleteTask(id);
            return Ok();
        }


    }
}

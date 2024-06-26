using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Interfaces;
using ToDoAPI.Model;
using ToDoAPI.ViewModel;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksController(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository ?? throw new ArgumentNullException(nameof(tasksRepository));
        }

        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            return Ok(_tasksRepository.Get(pageNumber, pageQuantity));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           
            return Ok(_tasksRepository.get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] TasksViewModel tasksView)
        {
            var tasks = new Tasks(tasksView.title, tasksView.description, tasksView.iscompleted, tasksView.CreatedDate, null, null);
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

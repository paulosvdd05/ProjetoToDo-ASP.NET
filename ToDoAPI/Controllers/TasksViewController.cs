using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Interfaces;

namespace ToDoAPI.Controllers
{
    public class TasksViewController : Controller
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksViewController(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public IActionResult Index()
        {
            var tasks = _tasksRepository.Get(0, 10); // Busca as primeiras 10 tarefas
            return View(tasks);
        }


    }
}

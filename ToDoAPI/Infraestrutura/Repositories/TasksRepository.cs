using ToDoAPI.Interfaces;
using ToDoAPI.Model;

namespace ToDoAPI.Infraestrutura.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void add(Tasks task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public List<Tasks> Get(int pageNumber, int pageQuantity)
        {
            return _context.Tasks.Skip(pageNumber * pageQuantity).Take(pageQuantity).ToList();
        }

        public Tasks get(int id)
        {
            return _context.Tasks.Find(id);
        }

        public void update(Tasks task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void MarkTaskAsCompleted(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                task.MarkAsCompleted();
                _context.SaveChanges();
            }
        }

        public void delete(Tasks task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public void deleteTask(int id)
        {
            var task = get(id);
            delete(task);
        }
    }
}

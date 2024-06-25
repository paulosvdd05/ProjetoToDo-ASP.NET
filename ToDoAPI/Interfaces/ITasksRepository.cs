using ToDoAPI.Model;

namespace ToDoAPI.Interfaces
{
    public interface ITasksRepository
    {
        void add(Tasks task);
        void update(Tasks task);
        void delete(Tasks task);

        List<Tasks> Get(int pageNumber, int pageQuantity);
        Tasks get(int id);


    }
}

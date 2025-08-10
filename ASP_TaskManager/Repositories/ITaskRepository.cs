using ASP_TaskManager.Models;

namespace ASP_TaskManager.Repositories
{
    public interface ITaskRepository
    {
        void SaveChanges();
        List<TaskItem> GetAll();

        TaskItem? GetById(int id);
        void Create(TaskItem task);
        void Delete(int id);
      
    }
}

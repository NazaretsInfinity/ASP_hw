using ASP_TaskManager.Models;

namespace ASP_TaskManager.Services
{
    public interface ITaskService
    {
        List<TaskItem> GetAllTasks();
        void CreateTask(string title,string? description);
        void ChangeTaskState(int id);
        void DeleteTask(int id);    

        TaskItem? GetTaskById(int id);
    }
}

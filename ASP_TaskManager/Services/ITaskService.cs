using ASP_TaskManager.Models;

namespace ASP_TaskManager.Services
{
    public interface ITaskService
    {
        List<TaskItem> GetAllTasks();
    }
}

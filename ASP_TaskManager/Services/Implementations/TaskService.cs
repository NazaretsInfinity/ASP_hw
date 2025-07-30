using ASP_TaskManager.Models;

namespace ASP_TaskManager.Services.Implementations
{
    public class TaskService : ITaskService
    {
        public List<TaskItem> GetAllTasks()
        {
            return new List<TaskItem>() {
                new TaskItem() {Title = "Task 1", Description="First task desc"},
                new TaskItem() {Title = "Task 2", Description="Second task desc"},
                new TaskItem() {Title="Task 3"}
            };
        }
    }
}

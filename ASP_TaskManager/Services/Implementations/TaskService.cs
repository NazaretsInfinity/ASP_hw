using ASP_TaskManager.Models;

namespace ASP_TaskManager.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly List<TaskItem> _tasks;
        private int _taskId;

        public TaskService()
        {
            _tasks = new List<TaskItem>();
            _taskId = 1;
        }
        public List<TaskItem> GetAllTasks() => _tasks;

        public void CreateTask(string title,string? description)
        {
            TaskItem task = new TaskItem()
            {
                Title = title,
                Description = description,
                Id = _taskId++
            };
            _tasks.Add(task);
        }

        public void ChangeTaskState(int id)
        {
            foreach (var task in _tasks) 
                if (task.Id == id)
                {
                    task.IsCompleted = !task.IsCompleted;
                    break;
                }
        }
    }
}

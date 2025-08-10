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
        public TaskItem? GetTaskById(int id)
        {
            foreach (var task in _tasks)
                if (task.Id == id)return task;
            return null;
        }

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
            TaskItem? task = GetTaskById(id) ?? throw new Exception(); //specify it later 
            task.IsCompleted = !task.IsCompleted;
        }

        public void DeleteTask(int id)
        {
            for (int i = 0; i < _tasks.Count; ++i)
                if (_tasks[i].Id == id)
                {
                    _tasks.RemoveAt(i);
                    break;
                }
        }
    }
}

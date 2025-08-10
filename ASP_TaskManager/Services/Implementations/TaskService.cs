using ASP_TaskManager.Models;
using ASP_TaskManager.Repositories;
using System.Threading.Tasks;

namespace ASP_TaskManager.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        int _taskId;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;

            int nextId = 0;
            foreach (var task in _taskRepository.GetAll())
                if (task.Id > nextId) nextId = task.Id;
            _taskId = nextId;
        }
        public List<TaskItem> GetAllTasks() => _taskRepository.GetAll();
        public TaskItem? GetTaskById(int id) => _taskRepository.GetById(id);

        public void CreateTask(string title,string? description)
        {
            TaskItem task = new TaskItem()
            {
                Title = title,
                Description = description,
                Id = _taskId++
            };
            _taskRepository.Create(task);
        }

        public void ChangeTaskState(int id)
        {
            TaskItem? task = GetTaskById(id) ?? throw new Exception(); //specify it later 
            task.IsCompleted = !task.IsCompleted;
        }

        public void DeleteTask(int id) => _taskRepository.Delete(id);
    }
}

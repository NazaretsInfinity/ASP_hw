using ASP_TaskManager.Models;
using System.Text.Json;

namespace ASP_TaskManager.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        const string FILE_PATH = "tasks.json";
        private readonly List<TaskItem> _tasks;


        public TaskRepository()
        {
            try
            {
                string json = File.ReadAllText(FILE_PATH);
                List<TaskItem>? tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? throw new Exception();
                _tasks = tasks;
            }
            catch (Exception)
            {
                _tasks = new List<TaskItem>();
            }
        }

        public void Create(TaskItem task)
        {
            _tasks.Add(task);
            SaveChanges();
        }

        public void Delete(int id)
        {
            for (int i = 0; i < _tasks.Count; ++i)
                if (_tasks[i].Id == id)
                {
                    _tasks.RemoveAt(i);
                    break;
                }
            SaveChanges();
        }

        public List<TaskItem> GetAll() => _tasks;

        public TaskItem? GetById(int id)
        {
            foreach (var task in _tasks)
                if (task.Id == id) return task;
            return null;
        }

        public void SaveChanges()
        {
            string json = JsonSerializer.Serialize(_tasks);
            File.WriteAllText(FILE_PATH, json);
        }
    }
}

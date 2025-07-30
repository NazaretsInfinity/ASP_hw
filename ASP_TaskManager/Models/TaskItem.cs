namespace ASP_TaskManager.Models
{
    public class TaskItem
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

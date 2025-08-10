using ASP_TaskManager.Services;
using ASP_TaskManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ASP_TaskManager.Pages
{
    public class EditTaskModel : PageModel
    {
        public ITaskService _taskService { get; set; }
        public EditTaskModel(ITaskService taskService)
        { 
            _taskService = taskService;
        }

        [BindProperty(Name ="id", SupportsGet =true)]
        public int TaskId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Task must have a name")]
        public required string Title { get; set; }

        [BindProperty]
        public string? Description { get; set; }

        [BindProperty]
        public bool IsCompleted { get; set; }

        [BindProperty]
        public DateTime CreatedAt { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            TaskItem? task = _taskService.GetTaskById(TaskId);
            if (task == null) 
                return RedirectToPage("/Index");
            task.Title = Title;
            task.Description = Description;
            task.CreatedAt = CreatedAt;
            task.IsCompleted = IsCompleted;


            return RedirectToPage("/Index");
        }

        public IActionResult OnGet()
        {
            TaskItem? task = _taskService.GetTaskById(TaskId);
            if (task is null)
                return RedirectToPage("/Index");

            Title = task.Title;
            Description = task.Description;
            IsCompleted = task.IsCompleted;
            CreatedAt = task.CreatedAt;
            return Page();
        }
    }
}

using ASP_TaskManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ASP_TaskManager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITaskService _taskService;
        public IndexModel(ITaskService taskService) { _taskService = taskService;}


        [BindProperty]
        [Required(ErrorMessage = "Task must have a name")]
        public required string Title { get; set; }

        [BindProperty]
        public string? Description { get; set; }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid) return Page();

            _taskService.CreateTask(Title, Description);
            return RedirectToPage("/Index");
        }

        public IActionResult OnGetChangeTaskState(int id)
        {
            _taskService.ChangeTaskState(id);
            return RedirectToPage("/Index");
        }
    }
}

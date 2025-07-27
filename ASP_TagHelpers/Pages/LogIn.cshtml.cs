using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ASP_TagHelpers.Pages
{
    public class LogInModel : PageModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [BindProperty(Name ="email")]
        public required string Email {  get; set; }


        [MinLength(6)]
        [Required]
        [DataType(DataType.Password)]
        [BindProperty(Name ="password")]
        public required string Password { get; set; }

        public string Message { get; set; } = null;
        public void OnPost()
        {
            if (ModelState.IsValid)
                Message = "success!";

        }
    }
}

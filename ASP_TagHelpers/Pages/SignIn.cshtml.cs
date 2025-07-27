using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ASP_TagHelpers.Pages
{
    public class SignInModel : PageModel
    {


        [MinLength(3)]
        [BindProperty]
        public required string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [BindProperty]
        public required string Email { get; set; }


        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage ="Must contain at least 6 symbols")]
        [BindProperty]
        public required string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="field doesn't match the password")]
        [BindProperty]
        public required string ConfirmedPassword { get; set; }

        public string? Message { get; set; }
        public void OnPost()
        {
            if(ModelState.IsValid)
            Message = $"User {Name} is registered!";   
        }
    }
}

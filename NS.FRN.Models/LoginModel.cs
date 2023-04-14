using System.ComponentModel.DataAnnotations;
namespace NS.FRN.Models
{
    public class LoginModel
    {
    // [Required(ErrorMessage ="Last Name is required")]
    // public string LastName { get; set; }
    [Required]
     [EmailAddress]
      [Display(Name = "Email")]
    [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,6}", ErrorMessage = "Incorrect Email Format")]
    public string Email { get; set; }
     [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
    
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_ASP.Net_Core_MVC_Project.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)] //to hide display when user is typing password
        public string Password { get; set; }

        [DataType(DataType.Password)]//to hide display when user is typing password
        [Display(Name = "Confirm password")] //displaying confirm-password label on the view for confirm password input
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

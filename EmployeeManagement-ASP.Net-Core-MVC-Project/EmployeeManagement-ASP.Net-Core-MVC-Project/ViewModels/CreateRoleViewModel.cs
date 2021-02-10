using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_ASP.Net_Core_MVC_Project.ViewModels
{
    public class CreateRoleViewModel
    {

        [Required]
        [Display(Name ="Role")]
        public string RoleName { get; set; }
    }
}

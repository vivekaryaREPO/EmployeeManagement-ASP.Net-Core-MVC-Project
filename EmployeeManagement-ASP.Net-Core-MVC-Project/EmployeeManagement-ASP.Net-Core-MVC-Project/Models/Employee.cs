using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_ASP.Net_Core_MVC_Project.Models
{
    public class Employee
    {
        //NOTE: VALUE TYPES SUCH AS INT, DECIMAL,FLOAT ARE Required by default, 
        //so you can't put null in it, untill you make the type nullable in model property.

        //we haven't given Id on the create form, this is why we don't see any validation
        //error message for that.
        public int Id { get; set; }

        [Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Display(Name = "Office Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        [Required]
        public string Email { get; set; }

 //[Required] // If you put Required and nullable=> It's mandatory field, and you can't put null in it, and you get required error when you enter null(default value)
     //If you put only nullable=> required error will not be shown, and it can be null, so null error isn't shown either.
     //if you put only required=> you get only null error if you dont'select right value
        
        [Required]
        public Dept? Department { get; set; }


        public string PhotoPath { get; set; }

    }
}

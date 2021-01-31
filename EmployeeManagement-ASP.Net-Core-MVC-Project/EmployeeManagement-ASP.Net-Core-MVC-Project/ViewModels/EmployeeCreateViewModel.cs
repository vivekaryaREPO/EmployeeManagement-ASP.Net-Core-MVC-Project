using EmployeeManagement_ASP.Net_Core_MVC_Project.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_ASP.Net_Core_MVC_Project.ViewModels
{
    public class EmployeeCreateViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Display(Name = "Office Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        [Required]
        public string Email { get; set; }

       
        [Required]
        public Dept? Department { get; set; }

        public List<IFormFile> Photos { set; get; }


        public IFormFile Photo { get; set; }//to allow upload single file


        public List<IFormFile> GetPhotos()
        {
            return Photos;
        }


        //public IFormFile Photo { get; set; }//to allow upload single file


        public void SetPhotos(List<IFormFile> value)
        {
            Photos = value;
        }
    }
}

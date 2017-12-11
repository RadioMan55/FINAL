using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class EmployeeSignIn
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }
}
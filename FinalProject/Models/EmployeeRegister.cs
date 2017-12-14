using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class EmployeeRegister
    {
        [Required]
        [StringLength(10)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(15)]
        [DisplayName("Username")]
        public string Username { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Password must be at last 4 characters.")]
        public string Password { get; set; }
        [StringLength(30)]
        [DisplayName("Title")]
        public string Title { get; set; }
        [StringLength(25)]
        [DisplayName("Title of Courtesy")]
        public string TitleOfCourtesy { get; set; }
        [DisplayName("Birth Date")]
        public Nullable<System.DateTime> BirthDate { get; set; }
        [DisplayName("Hire Date")]
        public Nullable<System.DateTime> HireDate { get; set; }
        [StringLength(60)]
        public string Address { get; set; }
        [StringLength(15)]
        public string City { get; set; }
        [StringLength(15)]
        public string Region { get; set; }
        [StringLength(10)]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
        [StringLength(15)]
        public string Country { get; set; }
        [Phone]
        [StringLength(24)]
        public string HomePhone { get; set; }
        [StringLength(4)]
        public string Extension { get; set; }
        [StringLength(10)]
        public int? ReportsTo { get; set; }
    }
}
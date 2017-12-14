using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class EmployeeEdit
    {
        [Required]
        [StringLength(20)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [StringLength(30)]
        [DisplayName("Title")]
        public string Title { get; set; }
        [Required]
        [StringLength(15)]
        [DisplayName("Username")]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Password")]
        public string Password { get; set; }
        [StringLength(25)]
        public string TitleOfCourtesy { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        [StringLength(60)]
        public string Address { get; set; }
        [StringLength(15)]
        public string City { get; set; }
        [StringLength(15)]
        public string Region { get; set; }
        [StringLength(10)]
        public string PostalCode { get; set; }
        [StringLength(15)]
        public string Country { get; set; }
        [Phone]
        [StringLength(24)]
        public string HomePhone { get; set; }
        [StringLength(4)]
        public string Extension { get; set; }
        [StringLength(10)]
        [DisplayName("Reports To")]
        public int? ReportsTo { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class OrderDTOs
    {
        public int OrderID { get; set; }
        public String OrderDate { get; set; }
        public String RequiredDate { get; set; }
        public String ShippedDate { get; set; }
        public int? CustomerID { get; set; }
        public int? EmployeeID { get; set; }

    }
}
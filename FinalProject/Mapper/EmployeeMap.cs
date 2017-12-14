using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Mapper
{
    public class EmployeeMap
    {
        public static EmployeeEdit Map(Employee employee)
        {
            return new EmployeeEdit()
            {
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Address = employee.Address,
                City = employee.City,
                Region = employee.Region,
                PostalCode = employee.PostalCode,
                Country = employee.Country,
                HomePhone = employee.HomePhone,
                Extension = employee.Extension,
                ReportsTo = employee.ReportsTo,
                Password = employee.Password,
                Username = employee.Username
            };
        }

        public static Employee Map(EmployeeEdit updatedemployee)
        {
            return new Employee()
            {
                LastName = updatedemployee.LastName,
                FirstName = updatedemployee.FirstName,
                Title = updatedemployee.Title,
                TitleOfCourtesy = updatedemployee.TitleOfCourtesy,
                BirthDate = updatedemployee.BirthDate,
                HireDate = updatedemployee.HireDate,
                Address = updatedemployee.Address,
                City = updatedemployee.City,
                Region = updatedemployee.Region,
                PostalCode = updatedemployee.PostalCode,
                Country = updatedemployee.Country,
                HomePhone = updatedemployee.HomePhone,
                Extension = updatedemployee.Extension,
                ReportsTo = updatedemployee.ReportsTo,
                Password = updatedemployee.Password,
                Username = updatedemployee.Username
            };
        }
    }
}
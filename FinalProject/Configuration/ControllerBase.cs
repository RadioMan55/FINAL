using AutoMapper;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Configuration
{
    public abstract class ControllerBase : Controller
    {
        protected readonly IMapper Mapper;

        protected ControllerBase()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Employee, EmployeeEdit>();
                x.CreateMap <EmployeeEdit, Employee>();
                x.CreateMap<EmployeeRegister, Employee>();
            });

            Mapper = config.CreateMapper();
        }
    }
}
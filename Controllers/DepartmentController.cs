using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demo.Models;

namespace demo.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            EmployeeContext employee = new EmployeeContext();
            List<Department> departments = employee.Departments.ToList(); 
            return View(departments);
        }
    }
}
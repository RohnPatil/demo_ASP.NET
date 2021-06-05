using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demo.Models;

namespace demo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(string departmentId)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            IList<Employee> employees = employeeContext.Employees.Where(emp => emp.Department.Equals(departmentId)).ToList();

            return View(employees);
        }

        public ActionResult Details(string id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(emp => emp.Id.Equals(id));

            return View(employee);
        }
        
    }
}
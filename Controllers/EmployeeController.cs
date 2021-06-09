using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using demo.Models;
using BusinessLayer;

namespace demo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        //public ActionResult Index(string departmentId)
        //{
        //    EmployeeContext employeeContext = new EmployeeContext();
        //    IList<Employee> employees = employeeContext.Employees.Where(emp => emp.Department.Equals(departmentId)).ToList();

        //    return View(employees);
        //}

        //public ActionResult Details(string id)
        //{
        //    EmployeeContext employeeContext = new EmployeeContext();
        //    Employee employee = employeeContext.Employees.Single(emp => emp.Id.Equals(id));

        //    return View(employee);
        //}
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();

            return View(employees);
        }

        //[HttpGet]
        //public ActionResult Create()
        //{

        //    return View();
        //}

        //Form Collection method
        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    Employee emplyoee = new Employee();
        //    emplyoee.Name = formCollection["Name"];
        //    emplyoee.Gender = formCollection["Gender"];
        //    emplyoee.City = formCollection["City"]; 
        //    emplyoee.Department = formCollection["Department"];

        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    employeeBusinessLayer.AddEmployee(emplyoee);

        //    return RedirectToAction("Index");
        //}



        //mapping data request to controller
        //[HttpPost]
        //public ActionResult Create(string name, string gender, string city, string department)
        //{
        //    Employee employee = new Employee();
        //    employee.Name = name;
        //    employee.Gender = gender;
        //    employee.City = city;
        //    employee.Department = department;

        //    EmployeeBusinessLayer employeeBusinessLayer =
        //        new EmployeeBusinessLayer();

        //    employeeBusinessLayer.AddEmployee(employee);
        //    return RedirectToAction("Index");
        //}

        //update model check cookies, cache and browser data to populate data
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer =
                    new EmployeeBusinessLayer();

                Employee employee = new Employee();
                UpdateModel(employee);

                employeeBusinessLayer.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}
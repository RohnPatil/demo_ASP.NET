using System;
using System.Collections.Generic;
using System.IO;
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




        //update model check cookies, cache and browser data to populate data
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        //normal create method
        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create_Post()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        EmployeeBusinessLayer employeeBusinessLayer =
        //            new EmployeeBusinessLayer();

        //        Employee employee = new Employee();
        //        UpdateModel(employee);

        //        employeeBusinessLayer.AddEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer =
                new EmployeeBusinessLayer();

            Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.ID.Equals(id));

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {

            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer =
                new EmployeeBusinessLayer();

                employeeBusinessLayer.SaveEmployee(employee);
                return RedirectToAction("Index");

            }

            return View(employee);
        }


        //[HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer =
                    new EmployeeBusinessLayer();

                Employee employee = new Employee();
                UpdateModel(employee);

                string fileName = Path.GetFileNameWithoutExtension(employee.ImageFile.FileName);
                string extension = Path.GetExtension(employee.ImageFile.FileName);
                fileName = fileName + extension;
                employee.ImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                employee.ImageFile.SaveAs(fileName);

                employeeBusinessLayer.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }


        ////file upload create method
        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create_Post()
        //{
        //    EmployeeBusinessLayer employeeBusinessLayer =
        //                new EmployeeBusinessLayer();

        //    Employee employee = new Employee();
        //    UpdateModel(employee);
        //    string fileName = Path.GetFileNameWithoutExtension(employee.ImageFile.FileName);
        //    string extension = Path.GetExtension(employee.ImageFile.FileName);
        //    fileName = fileName + extension;
        //    employee.ImagePath = "~/Images/" + fileName;
        //    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
        //    employee.ImageFile.SaveAs(fileName);
           

        //    employeeBusinessLayer.AddEmployee(employee);


        //    return View();
        //}
    }
}
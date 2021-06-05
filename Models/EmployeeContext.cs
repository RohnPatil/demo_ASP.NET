using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace demo.Models
{
    public class EmployeeContext : DbContext
    {
        // Replace square brackets, with angular brackets    
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
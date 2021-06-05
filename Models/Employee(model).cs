using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demo.Models
{
    [Table("tblEmployees")]  
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Department { get; set; }

    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApproach.Models
{
    public class Employees
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public decimal Salary { get; set; }
        
        public string Description { get; set; }

        public List<EmpProjects> EmployeeProjects { get; set; }
    }
}

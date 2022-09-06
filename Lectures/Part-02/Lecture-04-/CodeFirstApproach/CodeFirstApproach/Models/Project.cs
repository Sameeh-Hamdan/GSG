using System.Collections.Generic;

namespace CodeFirstApproach.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<EmpProjects> EmployeeProjects { get; set; }
    }
}

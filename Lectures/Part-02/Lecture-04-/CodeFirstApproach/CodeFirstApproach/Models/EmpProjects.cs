namespace CodeFirstApproach.Models
{
    public class EmpProjects
    {

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int EmployeesId { get; set; }
        public Employees Employees { get; set; }

    }
}

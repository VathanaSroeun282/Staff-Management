using staffmanagment_api.Controllers;

namespace staffmanagment_api.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; } = null!;
        public List<Employee>? Employees { get; set; }
    }
}

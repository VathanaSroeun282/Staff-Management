namespace staffmanagment_api.DTOs
{
    public class DepartmentDto
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; } = null!;

        // Optional: flatten employees to a list of strings (names) or IDs
        public List<string>? EmployeeNames { get; set; }
    }

    public class CreateDepartmentDto
    {
        public string DepartmentName { get; set; } = null!;
    }

    public class UpdateDepartmentDto
    {
        public string DepartmentName { get; set; } = null!;
    }
}

namespace staffmanagment_api.DTOs
{
    public class RoleDto
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } = null!;
        public List<string>? EmployeeName { get; set; }
    }

    public class CreateRoleDto
    {
        public string RoleName { get; set; } = null!;
    }

    public class UpdateRoleDto
    {
        public string RoleName { get; set; } = null!;
    }
}

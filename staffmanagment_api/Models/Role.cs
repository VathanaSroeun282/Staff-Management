using staffmanagment_api.Controllers;

namespace staffmanagment_api.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } = null!;
        public List<Employee>? Employees { get; set; }
    }

}

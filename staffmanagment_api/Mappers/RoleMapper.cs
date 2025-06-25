using staffmanagment_api.DTOs;
using staffmanagment_api.Models;

namespace staffmanagment_api.Mappers
{
    public class RoleMapper
    {
        public static RoleDto ToDto(Role role)
        {
            return new RoleDto
            {
                RoleID = role.RoleID,
                RoleName = role.RoleName,
                EmployeeName = role.Employees?.Select(e => e.FirstName).ToList() ?? new List<string>()
            };
        }

        public static Role FromCreateDto(CreateRoleDto dto)
        {
            return new Role
            {
                RoleName = dto.RoleName
            };
        }

        public static void UpdateFromDto(Role role, UpdateRoleDto dto)
        {
            role.RoleName = dto.RoleName;
        }
    }
}

using staffmanagment_api.DTOs;
using staffmanagment_api.Models;

namespace staffmanagment_api.Mappers
{
    public class DepartmentMapper
    {
        // Model → DTO
        public static DepartmentDto ToDto(Department dept)
        {
            return new DepartmentDto
            {
                DepartmentID = dept.DepartmentID,
                DepartmentName = dept.DepartmentName,
                EmployeeNames = dept.Employees != null
                    ? dept.Employees.Select(e => $"{e.FirstName} {e.LastName}").ToList()
                    : new List<string>()
            };
        }

        // Create DTO → Model
        public static Department FromCreateDto(CreateDepartmentDto dto)
        {
            return new Department
            {
                DepartmentName = dto.DepartmentName
            };
        }

        // Update DTO → Model
        public static void UpdateFromDto(Department dept, UpdateDepartmentDto dto)
        {
            dept.DepartmentName = dto.DepartmentName;
        }
    }
}

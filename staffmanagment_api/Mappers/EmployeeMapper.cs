using staffmanagment_api.Controllers;
using staffmanagment_api.DTOs.staffmanagment_api.DTOs;

namespace staffmanagment_api.Mappers
{
    public class EmployeeMapper
    {
        public static EmployeeDto ToDto(Employee employee)
        {
            return new EmployeeDto
            {
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                Position = employee.Position,
                HireDate = employee.HireDate,
                Salary = employee.Salary,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Status = employee.Status,
                DepartmentID = employee.DepartmentID,
                DepartmentName = employee.Department?.DepartmentName ?? "",
                RoleID = employee.RoleID,
                RoleName = employee.Role?.RoleName ?? ""
                // You can add lists like Attendances as separate DTO collections if needed
            };
        }

        public static Employee FromCreateDto(CreateEmployeeDto dto)
        {
            return new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Position = dto.Position,
                HireDate = dto.HireDate,
                Salary = dto.Salary,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Status = dto.Status,
                DepartmentID = dto.DepartmentID,
                RoleID = dto.RoleID
            };
        }

        public static void UpdateFromDto(Employee employee, UpdateEmployeeDto dto)
        {
            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.DateOfBirth = dto.DateOfBirth;
            employee.Position = dto.Position;
            employee.HireDate = dto.HireDate;
            employee.Salary = dto.Salary;
            employee.Email = dto.Email;
            employee.PhoneNumber = dto.PhoneNumber;
            employee.Status = dto.Status;
            employee.DepartmentID = dto.DepartmentID;
            employee.RoleID = dto.RoleID;
        }
    }
}

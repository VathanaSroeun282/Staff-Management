using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staffmanagment_api.Data.StaffManagementSystem.Data;
using staffmanagment_api.DTOs;

namespace staffmanagment_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext? _context;
        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        // Example action method to get all departments  
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var Department = new DepartmentDto
            {
                DepartmentID = 1,
                DepartmentName = "HR",
                EmployeeNames = new List<string> { "John Doe", "Jane Smith" }
            };
            var allDep = await _context!.Departments.Select(
                    e => new DepartmentDto
                    {
                        DepartmentID = e.DepartmentID,
                        DepartmentName = e.DepartmentName,
                        EmployeeNames = e.Employees != null ? e.Employees.Select(emp => emp.FirstName).ToList() : new List<string>()
                    }).ToListAsync();
            return Ok(Department);
        }
    }
}

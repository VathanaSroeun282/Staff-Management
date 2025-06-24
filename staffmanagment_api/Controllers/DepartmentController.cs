using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staffmanagment_api.Data.StaffManagementSystem.Data;
using staffmanagment_api.DTOs;
using staffmanagment_api.Models;

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
            var allDep = await _context!.Departments.Select(
                    e => new DepartmentDto
                    {
                        DepartmentID = e.DepartmentID,
                        DepartmentName = e.DepartmentName,
                        EmployeeNames = e.Employees != null ? e.Employees.Select(emp => emp.FirstName).ToList() : new List<string>()
                    }).ToListAsync();
            return Ok(allDep);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _context!.Departments
                .Include(d => d.Employees)
                .Select(d => new DepartmentDto
                {
                    DepartmentID = d.DepartmentID,
                    DepartmentName = d.DepartmentName,
                    EmployeeNames = d.Employees != null ? d.Employees.Select(emp => emp.FirstName).ToList() : new List<string>()
                })
                .FirstOrDefaultAsync(d => d.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreateDepartment(CreateDepartmentDto dto)
        {
            var department_find =await _context!.Departments.FirstOrDefaultAsync(d => d.DepartmentName == dto.DepartmentName);
            if(department_find != null)
            {
                return BadRequest("Department already exists");
            }
            await _context!.Departments.AddAsync(new Department
            {
                DepartmentName = dto.DepartmentName
            });
            await _context!.SaveChangesAsync();
            return Ok("Department was create");
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {   
            var find_department = await _context!.Departments.FindAsync(id);
            if (find_department == null)
            {
                return NotFound("Department not found");
            }
            _context!.Departments.Remove(find_department);
            await _context!.SaveChangesAsync();
            return Ok("Department was deleted");
        }
    }
}

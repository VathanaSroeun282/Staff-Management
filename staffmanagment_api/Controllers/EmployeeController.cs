using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staffmanagment_api.Data.StaffManagementSystem.Data;
using staffmanagment_api.DTOs;
using staffmanagment_api.DTOs.staffmanagment_api.DTOs;
using staffmanagment_api.Mappers;
using staffmanagment_api.Models;

namespace staffmanagment_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext appContext)
        {
            this._context = appContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _context!.Employees
                    .Include(emp => emp.Attendances)
                    .Include(emp => emp.AuditLogs)
                    .Include(emp => emp.Department)
                    .Include(emp => emp.LeaveRequests)
                    .Include(emp => emp.PerformanceReviews)
                    .Include(emp => emp.Role)
                    .Select(emp => EmployeeMapper.ToDto(emp))
                    .ToListAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } finally { await _context.DisposeAsync(); }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeByID(int id)
        {
            var employee = await _context!.Employees
                .Where(emp => emp.EmployeeID == id)
                .Include(emp => emp.Attendances)
                .Include(emp => emp.AuditLogs)
                .Include(emp => emp.Department)
                .Include(emp => emp.LeaveRequests)
                .Include(emp => emp.PerformanceReviews)
                .Include(emp => emp.Role)
                .Select(emp => EmployeeMapper.ToDto(emp))
                .FirstOrDefaultAsync();
            if (employee == null)
            {
                return BadRequest("Employee not found!");
            }
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> PostCreateEmployee(EmployeeDto.CreateEmployeeDto createEmployeeDto)
        {
            var find_attendance = await _context!.Employees.FirstOrDefaultAsync(emp => emp.DateOfBirth == createEmployeeDto.DateOfBirth && emp.FirstName == createEmployeeDto.FirstName && emp.LastName == createEmployeeDto.LastName && emp.Position == createEmployeeDto.Position);
            if (find_attendance != null)
            {
                return Ok("Employee existing in the list");
            }
            _context!.Employees.Add(EmployeeMapper.FromCreateDto(createEmployeeDto));
            await _context!.SaveChangesAsync();
            return Ok("New Employee have been added successfully!");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeByID(int id)
        {
            try
            {
                var find_employee = await _context!.Employees.FirstOrDefaultAsync(att => att.EmployeeID == id);
                if (find_employee != null)
                {
                    _context.Remove(find_employee);
                    await _context!.SaveChangesAsync();
                    return Ok($"The Employee ID = {id} was removed Successfully!");
                }
                return NotFound();
            }catch (Exception ex) { return  BadRequest(ex); }
            finally { _context.Dispose(); }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staffmanagment_api.Data.StaffManagementSystem.Data;
using staffmanagment_api.DTOs;

namespace staffmanagment_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly AppDbContext? _context;
        public RoleController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetRole()
        {
            try
            {
                //var allRole = "null";
                var allRole = await _context!.Roles.Select(
                    e => new RoleDto
                    {
                        RoleID = e.RoleID,
                        RoleName = e.RoleName,
                        EmployeeName = e.Employees != null ? e.Employees.Select(emp => emp.FirstName).ToList() : new List<string>()
                    }
                    ).ToListAsync();
                if (allRole == null || allRole.Count == 0)
                {
                    return NotFound("No roles found");
                }
                return Ok(allRole);
            }
            catch
            {
                return StatusCode(500, "Internal server error while fetching roles");
            }
        }
    }
}

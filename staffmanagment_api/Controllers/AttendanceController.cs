using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staffmanagment_api.Data.StaffManagementSystem.Data;
using staffmanagment_api.DTOs;

namespace staffmanagment_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly AppDbContext? _context;
        public AttendanceController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendances()
        {
            var attendances = await _context!.Attendances.Select(
                atd => new AttendanceDto
                {
                    AttendanceID = atd.AttendanceID,
                    EmployeeID = atd.EmployeeID,
                    EmployeeName = atd.Employee != null ? atd.Employee.FirstName : "Unknown",
                    ClockInTime = atd.ClockInTime,
                    ClockOutTime = atd.ClockInTime
                }
                ).ToArrayAsync();
            return Ok(attendances);
        }
    }
}

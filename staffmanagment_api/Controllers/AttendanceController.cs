using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staffmanagment_api.Data.StaffManagementSystem.Data;
using staffmanagment_api.DTOs;
using staffmanagment_api.Mappers;
using staffmanagment_api.Models;

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
            var attendances = await _context!.Attendances.Include(pfr => pfr.Employee).Select(
                atd => AttendanceMapper.ToDto(atd)
                ).ToArrayAsync();
            return Ok(attendances);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendanceByID(int id)
        {
            var attendance  = await _context!.Attendances
                .Where(att => att.AttendanceID == id)
                .Select(att=> AttendanceMapper.ToDto(att))
                .FirstOrDefaultAsync();
            if(attendance == null)
            {
                return BadRequest("Attendances not found!");
            }
            return Ok(attendance);
        }
        [HttpPost]
        public async Task<IActionResult> PostCreateAttendace(CreateAttendanceDto createAttendanceDto)
        {
            var find_attendance = await _context!.Attendances
                                   .FirstOrDefaultAsync(att => att.ClockInTime == createAttendanceDto.ClockInTime 
                                                        && att.ClockOutTime == createAttendanceDto.ClockOutTime);
            if(find_attendance != null)
            {
                return Ok("Attendance existing in the list");
            }
            _context!.Attendances.Add(AttendanceMapper.FromCreateDto(createAttendanceDto));
            await _context!.SaveChangesAsync();
            return Ok("Attendance added!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendanceByID(int id)
        {
            var find_attendance = await _context!.Attendances.FirstOrDefaultAsync(att => att.AttendanceID == id);
            if(find_attendance != null)
            {
                _context.Remove(find_attendance);
                await _context!.SaveChangesAsync();
                return Ok($"The attendance id = {id} was remove");
            }
            return NotFound();
        }
    }
}

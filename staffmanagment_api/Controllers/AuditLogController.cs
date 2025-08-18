
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staffmanagment_api.Data.StaffManagementSystem.Data;
using staffmanagment_api.Mappers;

namespace staffmanagment_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditLogController : ControllerBase
    {
        private readonly AppDbContext? _dbContext;
        public AuditLogController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAttendances()
        {
            try
            {
                var all_attedances = await _dbContext!.AuditLogs.Include(aud => aud.Employee).Select(aud => AuditLogMapper.ToDto(aud)).ToArrayAsync();
                if(all_attedances.Any())
                {
                    return Ok(all_attedances);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuditLogByID(int id)
        {
            var find_auditLog = await _dbContext!.AuditLogs.FindAsync(id);
            if (find_auditLog == null) return NotFound();
            return Ok(find_auditLog);
        }
    }
}

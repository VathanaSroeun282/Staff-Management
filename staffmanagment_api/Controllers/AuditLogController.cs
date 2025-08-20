
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using staffmanagment_api.Data.StaffManagementSystem.Data;
using staffmanagment_api.DTOs.staffmanagment_api.DTOs;
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
                var all_attedances = await _dbContext!.AuditLogs
                    .Include(aud => aud.Employee)
                    .Select(aud => AuditLogMapper.ToDto(aud))
                    .ToArrayAsync();
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
            try
            {
                var find_auditLog = await _dbContext!.AuditLogs.FindAsync(id);
                if (find_auditLog == null) return NotFound($"ID = {id} not found!");
                return Ok(find_auditLog);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            finally { _dbContext?.Dispose(); }
        }
        [HttpPost]
        public async Task<IActionResult> PostAddNewAuditLog(CreateAuditLogDto createAuditLogDto)
        {
            var find_auditLog = await _dbContext!.AuditLogs.FirstOrDefaultAsync(aud => aud.EmployeeID == createAuditLogDto.EmployeeID && aud.ChangeDate == createAuditLogDto.ChangeDate);
            if(find_auditLog != null)
            {
                return NotFound("This AuditLog already existing!");
            }
            await _dbContext!.AuditLogs.AddAsync(AuditLogMapper.FromCreateDto(createAuditLogDto));
            await _dbContext!.SaveChangesAsync();
            return Ok("This AuditLog already add to the list!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuditLog(int id)
        {

            try
            {
                var find_auditLog = await _dbContext!.AuditLogs.FindAsync(id);
                if (find_auditLog == null) return NotFound($"ID = {id} not found!");
                _dbContext!.AuditLogs.Remove(find_auditLog);
                await _dbContext!.SaveChangesAsync();
                return Ok("This AuditLog delete successful!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            finally { _dbContext?.Dispose(); }
        }
    }
}

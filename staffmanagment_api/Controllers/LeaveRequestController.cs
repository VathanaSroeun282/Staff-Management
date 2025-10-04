using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staffmanagment_api.Data.StaffManagementSystem.Data;
using staffmanagment_api.DTOs.staffmanagment_api.DTOs;
using staffmanagment_api.Mappers;

namespace staffmanagment_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestController : Controller
    {
        private readonly AppDbContext _dbContext;
        public LeaveRequestController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLeaveRequests()
        {
            try
            {
                var allLeaveRequests = (await _dbContext!.LeaveRequests
                .Include(le => le.Employee)   // include employee data
                .ToListAsync())
                .Select(LeaveRequestMapper.ToDto)
                .ToArray();

                if (allLeaveRequests.Any())
                {
                    return Ok(allLeaveRequests);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally { _dbContext.Dispose(); }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeaveRequestByID(int id)
        {
            try
            {
                var find_leaveRequest = await _dbContext!.LeaveRequests.Include(le => le.Employee).Where(le => le.LeaveRequestID == id)
                                .Select(le => LeaveRequestMapper.ToDto(le)).FirstOrDefaultAsync();
                if (find_leaveRequest == null) return NotFound();
                return Ok(find_leaveRequest);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally { _dbContext.Dispose(); }
        }
        [HttpPost]
        public async Task<IActionResult> AddNewLeaveRequest(CreateLeaveRequestDto leaveRequestDto)
        {
            try
            {
                var find_leaveRequest = await _dbContext!.LeaveRequests.FirstOrDefaultAsync(lr=>lr.EmployeeID == leaveRequestDto.EmployeeID);
                if ( find_leaveRequest != null)
                {
                    _dbContext!.LeaveRequests.Add(LeaveRequestMapper.FromCreateDto(leaveRequestDto));
                    await _dbContext.SaveChangesAsync();
                    return Ok("Your Request Leave have been added");
                }
                return NotFound($"Employee ID={leaveRequestDto.EmployeeID} Not found in the System!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally { _dbContext.Dispose(); }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteLeaveRequest(int id)
        {
            try
            {
                var find_leaveRequest = await _dbContext!.LeaveRequests.FindAsync(id);
                if (find_leaveRequest != null) return NotFound($"Leave Request ID = {id} Not Found!!!");
                _dbContext!.LeaveRequests.Remove(find_leaveRequest);
                await _dbContext.SaveChangesAsync();
                return Ok($"Leave Request ID = {id} have been delete!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally { _dbContext.Dispose(); }
        }
    }
}

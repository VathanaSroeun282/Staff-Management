using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staffmanagment_api.Data.StaffManagementSystem.Data;
using staffmanagment_api.DTOs;
using staffmanagment_api.Mappers;

namespace staffmanagment_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerformanceReviewController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public PerformanceReviewController(AppDbContext appDbContext)
        {
            this._dbContext = appDbContext; 
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPerformanceReview()
        {
            try
            {
                var all_PerformanceReview = await _dbContext!.PerformanceReviews
                                .Include(ptr => ptr.Employee)
                                .Select(pfr => PerformanceReviewMapper.ToDto(pfr))
                                .ToListAsync();
                if (all_PerformanceReview.Any())
                {
                    return Ok(all_PerformanceReview);
                }
                return NotFound("Don't have any record in PerformanceReviews table");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            finally { _dbContext.Dispose(); }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAPerformanceReview(int id)
        {
            try
            {
                var all_PerformanceReview = await _dbContext!.PerformanceReviews
                    .Include(pfr=>pfr.Employee)
                    .Where(pfr => pfr.ReviewID == id)
                    .Select(pfr => PerformanceReviewMapper.ToDto(pfr))
                    .FirstOrDefaultAsync();
                if (all_PerformanceReview != null)
                {
                    return Ok(all_PerformanceReview);
                }
                return NotFound("Don't have any record in PerformanceReviews table");
            }
            catch (Exception ex)   
            {
                return BadRequest(ex);
            }
            finally { _dbContext.Dispose(); }
        }
        [HttpPost]
        public async Task<IActionResult> PostAddNewPerformanceReview(CreatePerformanceReviewDto createPerformanceReviewDto)
        {
            try
            {
                _dbContext.Add(PerformanceReviewMapper.FromCreateDto(createPerformanceReviewDto));
                await _dbContext.SaveChangesAsync();
                return Ok("New Performance-Review was added");
            }
            catch (Exception ex) { return BadRequest(ex); }
            finally { _dbContext.Dispose(); }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePerformanceReview(int id)
        {
            try
            {
                var find_PerformanceReview = _dbContext!.PerformanceReviews?.FindAsync(id);
                if (find_PerformanceReview == null) { return NotFound(); }
                _dbContext!.Remove(find_PerformanceReview);
                await _dbContext.SaveChangesAsync();
                return Ok($"You have been delete a Performance-Review ID={id}");
            }
            catch (Exception ex){ return BadRequest(ex); }
            finally { _dbContext.Dispose(); }
        }
    }
}
  
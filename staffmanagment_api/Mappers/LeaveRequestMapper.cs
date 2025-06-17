using staffmanagment_api.DTOs.staffmanagment_api.DTOs;
using staffmanagment_api.Models;

namespace staffmanagment_api.Mappers
{
    public class LeaveRequestMapper
    {
        public static LeaveRequestDto ToDto(LeaveRequest leave)
        {
            return new LeaveRequestDto
            {
                LeaveRequestID = leave.LeaveRequestID,
                LeaveType = leave.LeaveType,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                Reason = leave.Reason,
                Status = leave.Status,
                EmployeeID = leave.EmployeeID,
                EmployeeName = leave.Employee?.FirstName + " " + leave.Employee?.LastName ?? ""
            };
        }

        public static LeaveRequest FromCreateDto(CreateLeaveRequestDto dto)
        {
            return new LeaveRequest
            {
                LeaveType = dto.LeaveType,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Reason = dto.Reason,
                EmployeeID = dto.EmployeeID,
                Status = "Pending"  // default
            };
        }

        public static void UpdateFromDto(LeaveRequest leave, UpdateLeaveRequestDto dto)
        {
            leave.Status = dto.Status;
            // Add other updatable fields here if needed
        }
    }
}

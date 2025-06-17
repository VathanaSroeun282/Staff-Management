using staffmanagment_api.DTOs;
using staffmanagment_api.Models;

namespace staffmanagment_api.Mappers
{
    public class AttendanceMapper
    {
        // Model → DTO
        public static AttendanceDto ToDto(Attendance attendance)
        {
            return new AttendanceDto
            {
                AttendanceID = attendance.AttendanceID,
                ClockInTime = attendance.ClockInTime,
                ClockOutTime = attendance.ClockOutTime,
                EmployeeID = attendance.EmployeeID,
                EmployeeName = attendance.Employee != null
                    ? $"{attendance.Employee.FirstName} {attendance.Employee.LastName}"
                    : string.Empty
            };
        }

        // Create DTO → Model
        public static Attendance FromCreateDto(CreateAttendanceDto dto)
        {
            return new Attendance
            {
                ClockInTime = dto.ClockInTime,
                ClockOutTime = dto.ClockOutTime,
                EmployeeID = dto.EmployeeID
            };
        }

        // Update DTO → Model (update existing entity)
        public static void UpdateFromDto(Attendance attendance, UpdateAttendanceDto dto)
        {
            attendance.ClockInTime = dto.ClockInTime;
            attendance.ClockOutTime = dto.ClockOutTime;
            // EmployeeID is not updated here, but add if needed
        }
    }
}

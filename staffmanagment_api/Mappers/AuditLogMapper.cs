using staffmanagment_api.DTOs.staffmanagment_api.DTOs;
using staffmanagment_api.Models;

namespace staffmanagment_api.Mappers
{
    public class AuditLogMapper
    {
        // Model → DTO
        public static AuditLogDto ToDto(AuditLog log)
        {
            return new AuditLogDto
            {
                AuditLogID = log.AuditLogID,
                ChangeType = log.ChangeType,
                ChangeDate = log.ChangeDate,
                ChangedBy = log.ChangedBy,
                EmployeeID = log.EmployeeID,
                EmployeeName = log.Employee != null
                    ? $"{log.Employee.FirstName} {log.Employee.LastName}"
                    : string.Empty
            };
        }

        // Create DTO → Model
        public static AuditLog FromCreateDto(CreateAuditLogDto dto)
        {
            return new AuditLog
            {
                ChangeType = dto.ChangeType,
                ChangeDate = dto.ChangeDate,
                ChangedBy = dto.ChangedBy,
                EmployeeID = dto.EmployeeID
            };
        }

        // Usually audit logs are not updated, so no UpdateFromDto method is needed
    }
}

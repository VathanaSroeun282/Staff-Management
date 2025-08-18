namespace staffmanagment_api.DTOs
{
    namespace staffmanagment_api.DTOs
    {
        public class AuditLogDto
        {
            public int AuditLogID { get; set; }
            public string ChangeType { get; set; } = null!;
            public DateTime ChangeDate { get; set; }
            public int ChangedBy { get; set; }
            //public int EmployeeID { get; set; }

            // Optional: flatten employee name to send with audit log
            public string EmployeeName { get; set; } = string.Empty;
        }

        public class CreateAuditLogDto
        {
            public string ChangeType { get; set; } = null!;
            public DateTime ChangeDate { get; set; }
            public int ChangedBy { get; set; }
            public int EmployeeID { get; set; }
        }
    }
}

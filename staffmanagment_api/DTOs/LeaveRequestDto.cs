namespace staffmanagment_api.DTOs
{
    namespace staffmanagment_api.DTOs
    {
        public class LeaveRequestDto
        {
            public int LeaveRequestID { get; set; }
            public string LeaveType { get; set; } = null!;
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string? Reason { get; set; }
            public string Status { get; set; } = "Pending";
            public int EmployeeID { get; set; }

            // Flattened employee name for easy display
            public string EmployeeName { get; set; } = null!;
        }

        public class CreateLeaveRequestDto
        {
            public string LeaveType { get; set; } = null!;
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string? Reason { get; set; }
            public int EmployeeID { get; set; }
        }

        public class UpdateLeaveRequestDto
        {
            public string Status { get; set; } = null!;
        }
    }
}

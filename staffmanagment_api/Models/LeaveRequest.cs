using staffmanagment_api.Controllers;

namespace staffmanagment_api.Models
{
    public class LeaveRequest
    {
        public int LeaveRequestID { get; set; }
        public string LeaveType { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Reason { get; set; }


        public string Status { get; set; } = "Pending";
        // Foreign key to Employee
        public int EmployeeID { get; set; }
        // Navigation property to Employee
        public Employee Employee { get; set; } = null!;
    }
}

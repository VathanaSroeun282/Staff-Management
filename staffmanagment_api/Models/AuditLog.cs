using staffmanagment_api.Controllers;

namespace staffmanagment_api.Models
{
    public class AuditLog
    {
        public int AuditLogID { get; set; }
        public string ChangeType { get; set; } = null!;
        public DateTime ChangeDate { get; set; }
        public int ChangedBy { get; set; }

        //Foreign key to Employee
        public int EmployeeID { get; set; }
        // Navigation property to Employee
        public Employee Employee { get; set; } = null!;
        
    }

}

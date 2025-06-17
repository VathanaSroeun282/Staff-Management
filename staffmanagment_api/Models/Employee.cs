using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staffmanagment_api.Data;
using staffmanagment_api.Data.StaffManagementSystem.Data;
using staffmanagment_api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace staffmanagment_api.Controllers
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; } = null!;
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Status { get; set; } = "Active";

        // Navigation properties
        // This property allows us to navigate from an Employee to their Department
        public Department Department { get; set; } = null!; // Navigation property to Department
        public int DepartmentID { get; set; } // Foreign key to Department

        // This property allows us to navigate from an Employee to their Role
        public Role Role { get; set; } = null!; // Navigation property to Role
        public int RoleID { get; set; } // Foreign key to Role

        // This property allows us to navigate from an Employee to their Attendance records
        public List<Attendance>? Attendances { get; set; } // Navigation property to Attendance records

        // This property allows us to navigate from an Employee to their Performance records
        public List<PerformanceReview>? PerformanceReviews { get; set; } // Navigation property to PerformanceReview records

        // This property allows us to navigate from an Employee to their Audit records
        public List<AuditLog>? AuditLogs { get; set; } // Navigation property to Audit records

        // This property allows us to navigate from an Employee to their LeaveRequest records
        public List<LeaveRequest>? LeaveRequests { get; set; } // Navigation property to LeaveRequest records
    }

}

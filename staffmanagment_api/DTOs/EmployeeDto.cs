namespace staffmanagment_api.DTOs
{
    namespace staffmanagment_api.DTOs
    {
        public class EmployeeDto
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

            public int DepartmentID { get; set; }
            public string DepartmentName { get; set; } = null!;

            public int RoleID { get; set; }
            public string RoleName { get; set; } = null!;

            // Optional: counts of related entities instead of full lists
            public int AttendanceCount { get; set; }
            public int PerformanceReviewCount { get; set; }
            public int AuditLogCount { get; set; }
            public int LeaveRequestCount { get; set; }
        }

        public class CreateEmployeeDto
        {
            public string FirstName { get; set; } = null!;
            public string LastName { get; set; } = null!;
            public DateTime DateOfBirth { get; set; }
            public string Position { get; set; } = null!;
            public DateTime HireDate { get; set; }
            public decimal Salary { get; set; }
            public string Email { get; set; } = null!;
            public string PhoneNumber { get; set; } = null!;
            public string Status { get; set; } = "Active";

            public int DepartmentID { get; set; }
            public int RoleID { get; set; }
        }

        public class UpdateEmployeeDto
        {
            public string FirstName { get; set; } = null!;
            public string LastName { get; set; } = null!;
            public DateTime DateOfBirth { get; set; }
            public string Position { get; set; } = null!;
            public DateTime HireDate { get; set; }
            public decimal Salary { get; set; }
            public string Email { get; set; } = null!;
            public string PhoneNumber { get; set; } = null!;
            public string Status { get; set; } = "Active";

            public int DepartmentID { get; set; }
            public int RoleID { get; set; }
        }
    }
}

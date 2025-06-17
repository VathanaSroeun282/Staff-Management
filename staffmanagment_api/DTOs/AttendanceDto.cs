namespace staffmanagment_api.DTOs
{
    public class AttendanceDto
    {
        public int AttendanceID { get; set; }
        public DateTime ClockInTime { get; set; }
        public DateTime ClockOutTime { get; set; }
        public int EmployeeID { get; set; }

        // Optional: flatten Employee data if you want to return some employee details in AttendanceDto
        public string EmployeeName { get; set; } = string.Empty;
    }

    public class CreateAttendanceDto
    {
        public DateTime ClockInTime { get; set; }
        public DateTime ClockOutTime { get; set; }
        public int EmployeeID { get; set; }
    }

    public class UpdateAttendanceDto
    {
        public DateTime ClockInTime { get; set; }
        public DateTime ClockOutTime { get; set; }
    }
}

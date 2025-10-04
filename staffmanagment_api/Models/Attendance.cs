using staffmanagment_api.Controllers;

namespace staffmanagment_api.Models
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public DateTime ClockInTime { get; set; }
        public DateTime ClockOutTime { get; set; }

        //Property 
        //Property to hold the EmployeeID of the employee associated with this attendance record
        //Navigation property to the Employee associated with this attendance record
        public int EmployeeID { get; set; }
        public Employee ? Employee { get; set; }

    }

}

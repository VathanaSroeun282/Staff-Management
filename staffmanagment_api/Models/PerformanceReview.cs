using System.ComponentModel.DataAnnotations;
using staffmanagment_api.Controllers;

namespace staffmanagment_api.Models
{
    public class PerformanceReview
    {
        [Key]
        public int ReviewID { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }

        // Foreign key to Employee
        public int EmployeeID { get; set; }
        // Navigation property to Employee
        public Employee Employee { get; set; } = null!;
    }

}

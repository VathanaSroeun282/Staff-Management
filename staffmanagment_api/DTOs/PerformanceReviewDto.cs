namespace staffmanagment_api.DTOs
{
    public class PerformanceReviewDto
    {
        public int ReviewID { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }
        public int EmployeeID { get; set; }

        // Flattened employee name
        public string EmployeeName { get; set; } = null!;
    }

    public class CreatePerformanceReviewDto
    {
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }
        public int EmployeeID { get; set; }
    }

    public class UpdatePerformanceReviewDto
    {
        public int Rating { get; set; }
        public string? Comments { get; set; }
    }
}

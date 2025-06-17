using staffmanagment_api.DTOs;
using staffmanagment_api.Models;

namespace staffmanagment_api.Mappers
{
    public class PerformanceReviewMapper
    {
        public static PerformanceReviewDto ToDto(PerformanceReview review)
        {
            return new PerformanceReviewDto
            {
                ReviewID = review.ReviewID,
                ReviewDate = review.ReviewDate,
                Rating = review.Rating,
                Comments = review.Comments,
                EmployeeID = review.EmployeeID,
                EmployeeName = review.Employee?.FirstName + " " + review.Employee?.LastName ?? ""
            };
        }

        public static PerformanceReview FromCreateDto(CreatePerformanceReviewDto dto)
        {
            return new PerformanceReview
            {
                ReviewDate = dto.ReviewDate,
                Rating = dto.Rating,
                Comments = dto.Comments,
                EmployeeID = dto.EmployeeID
            };
        }

        public static void UpdateFromDto(PerformanceReview review, UpdatePerformanceReviewDto dto)
        {
            review.Rating = dto.Rating;
            review.Comments = dto.Comments;
        }
    }
}

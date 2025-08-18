namespace staffmanagment_api.Data
{
    using Microsoft.EntityFrameworkCore;
    using StaffManagementSystem.Data;
    using staffmanagment_api.Controllers;
    using staffmanagment_api.Models;

    namespace StaffManagementSystem.Data
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options) { }

            public DbSet<Department> Departments { get; set; }
            public DbSet<Role> Roles { get; set; }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Attendance> Attendances { get; set; }
            public DbSet<LeaveRequest> LeaveRequests { get; set; }
            public DbSet<PerformanceReview> PerformanceReviews { get; set; }
            public DbSet<AuditLog> AuditLogs { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //Department with Employee relationship
                modelBuilder.Entity<Employee>()
                    .HasOne(e => e.Department)
                    .WithMany(d => d.Employees)
                    .HasForeignKey(e => e.DepartmentID);

                //Role with Employee relationship
                modelBuilder.Entity<Employee>()
                    .HasOne(e => e.Role)
                    .WithMany(r => r.Employees)
                    .HasForeignKey(e => e.RoleID);


                //Employee with PerformanceReview relationship
                modelBuilder.Entity<PerformanceReview>()
                    .HasOne(pr => pr.Employee)
                    .WithMany(e => e.PerformanceReviews)
                    .HasForeignKey(pr => pr.EmployeeID);

                //Employee with AuditLog relationship
                modelBuilder.Entity<AuditLog>()
                    .HasOne(al => al.Employee)
                    .WithMany(e => e.AuditLogs)
                    .HasForeignKey(al => al.EmployeeID);

                //Employee with LeaveRequest relationship
                modelBuilder.Entity<LeaveRequest>()
                    .HasOne(lr => lr.Employee)
                    .WithMany(e => e.LeaveRequests)
                    .HasForeignKey(lr => lr.EmployeeID);
            }
        }
    }
}

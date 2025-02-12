using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Employee_Management_Vacation_Request.Entities
{
    public class EmployeeManagementDbContext : DbContext
    {
        // DbSet for Department entity
        public DbSet<Department> Departments { get; set; }

        // DbSet for Position entity
        public DbSet<Position> Positions { get; set; }

        // DbSet for Employee entity
        public DbSet<Employee> Employees { get; set; }

        // DbSet for VacationType entity
        public DbSet<VacationType> VacationTypes { get; set; }

        // DbSet for RequestState entity
        public DbSet<RequestState> RequestStates { get; set; }

        // DbSet for VacationRequest entity
        public DbSet<VacationRequest> VacationRequests { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-QAD3CRN\\SQLEXPRESS;Database=Employeen_Management_Vacatio_DB;User Id=sa;Password=Shining15244184$;TrustServerCertificate=True;")
            .LogTo(Console.WriteLine, LogLevel.Information); // Log SQL queries to the console
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the one-to-many relationship between Department and Employee
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department) // Employee has one Department
                .WithMany(d => d.Employees) // Department has many Employees
                .HasForeignKey(e => e.DepartmentId); // Foreign key in Employee

            // Configure the one-to-many relationship between Position and Employee
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Position) // Employee has one Position
                .WithMany(p => p.Employees) // Position has many Employees
                .HasForeignKey(e => e.PositionId); // Foreign key in Employee

            // Configure the self-referencing relationship for ReportedToEmployeeNumber
            modelBuilder.Entity<Employee>()
                // Configure EmployeeId as a non-identity column (if not using data annotations)
                // .Property(p => p.EmployeeNumber)
                // .ValueGeneratedNever() // Disable identity/auto-increment
                .HasOne(e => e.ReportedToEmployee) // Employee reports to another Employee
                .WithMany() // An employee can have multiple subordinates
                .HasForeignKey(e => e.ReportedToEmployeeNumber) // Foreign key in Employee
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Configure the one-to-many relationship between Employee and VacationRequest (submitted by)
            modelBuilder.Entity<VacationRequest>()
                .HasOne(v => v.Employee) // VacationRequest belongs to one Employee
                .WithMany(e => e.VacationRequests) // Employee has many VacationRequests
                .HasForeignKey(v => v.EmployeeNumber); // Foreign key in VacationRequest

            // Configure the one-to-many relationship between VacationType and VacationRequest
            modelBuilder.Entity<VacationRequest>()
                .HasOne(v => v.VacationType) // VacationRequest has one VacationType
                .WithMany(vt => vt.VacationRequests) // VacationType has many VacationRequests
                .HasForeignKey(v => v.VacationTypeCode); // Foreign key in VacationRequest

            // Configure the one-to-many relationship between RequestState and VacationRequest
            modelBuilder.Entity<VacationRequest>()
                .HasOne(v => v.RequestState) // VacationRequest has one RequestState
                .WithMany(rs => rs.VacationRequests) // RequestState has many VacationRequests
                .HasForeignKey(v => v.RequestStateId); // Foreign key in VacationRequest

            // Configure the optional relationship between Employee and VacationRequest (approved by)
            modelBuilder.Entity<VacationRequest>()
                .HasOne(v => v.ApprovedByEmployee) // VacationRequest can be approved by one Employee
                .WithMany(e => e.ApprovedVacationRequests) // Employee can approve many VacationRequests
                .HasForeignKey(v => v.ApprovedByEmployeeNumber) // Foreign key in VacationRequest
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Configure the optional relationship between Employee and VacationRequest (declined by)
            modelBuilder.Entity<VacationRequest>()
                .HasOne(v => v.DeclinedByEmployee) // VacationRequest can be declined by one Employee
                .WithMany(e => e.DeclinedVacationRequests) // Employee can decline many VacationRequests
                .HasForeignKey(v => v.DeclinedByEmployeeNumber) // Foreign key in VacationRequest
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete


            // Seed RequestStates
            modelBuilder.Entity<RequestState>().HasData(
                new RequestState { StateId = 1, StateName = "Submitted" },
                new RequestState { StateId = 2, StateName = "Approved" },
                new RequestState { StateId = 3, StateName = "Declined" }
            );

            // Seed VacationTypes
            modelBuilder.Entity<VacationType>().HasData(
                new VacationType { VacationTypeCode = 'S', VacationTypeName = "Sick" },
                new VacationType { VacationTypeCode = 'U', VacationTypeName = "Unpaid" },
                new VacationType { VacationTypeCode = 'A', VacationTypeName = "Annual" },
                new VacationType { VacationTypeCode = 'O', VacationTypeName = "Day Off" },
                new VacationType { VacationTypeCode = 'B', VacationTypeName = "Business Trip" }
            );
        }

    }
}

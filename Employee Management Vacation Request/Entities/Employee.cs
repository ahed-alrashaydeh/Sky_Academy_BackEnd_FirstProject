using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Vacation_Request.Entities
{
    // Employee Entity
    public class Employee
    {
        [Key]
        [Required]
        [MaxLength(6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Disable identity/auto-increment
        // .ValueGeneratedNever(); // Disable identity/auto-increment // Alternative(If not using data annotations)/(put this line before the property in EmployeeManagementDbContext)
        public string EmployeeNumber { get; set; } // Primary Key, Not Identity, Max 6 characters

        [Required]
        [MaxLength(20)]
        public string EmployeeName { get; set; } // Required, Max 20 characters

        // Foreign key to Department
        public int DepartmentId { get; set; } // Foreign Key

        // Navigation property to Department
        [Required]
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        // Foreign key to Position
        public int PositionId { get; set; } // Foreign Key

        // Navigation property to Position
        [Required]
        [ForeignKey("PositionId")]
        public Position Position { get; set; }

        [Required]
        [MaxLength(1)]
        public char GenderCode { get; set; } // Required, Max 1 character (M: Male, F: Female)

        [MaxLength(6)]
        public string? ReportedToEmployeeNumber { get; set; } // Nullable, Max 6 characters

        // Navigation property to self (Employee reports to another Employee)
        [ForeignKey("ReportedToEmployeeNumber")]
        public Employee ReportedToEmployee { get; set; }

        [Range(0, 24)]
        public int VacationDaysLeft { get; set; } // Integer, cannot exceed 24 days

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; } // Decimal with max 2 digits after decimal point

        // Navigation property for subordinates (Employees who report to this Employee)
        public ICollection<Employee> Subordinates { get; set; } = new List<Employee>();

        // Navigation property for VacationRequests
        // property establishes a one-to-many relationship between Employee and VacationRequest.
        public ICollection<VacationRequest> VacationRequests { get; set; } = new List<VacationRequest>();

        // Navigation property for VacationRequests approved by this employee
        public ICollection<VacationRequest> ApprovedVacationRequests { get; set; } = new List<VacationRequest>();

        // Navigation property for VacationRequests declined by this employee
        public ICollection<VacationRequest> DeclinedVacationRequests { get; set; } = new List<VacationRequest>();


        // Constructor
        public Employee(
            string employeeNumber,
            string employeeName,
            int departmentId,
            int positionId,
            char genderCode,
            decimal salary,
            string? reportedToEmployeeNumber,
            int vacationDaysLeft = 24) // Default value for vacationDaysLeft
        {
            EmployeeNumber = employeeNumber;
            EmployeeName = employeeName;
            DepartmentId = departmentId;
            PositionId = positionId;
            GenderCode = genderCode;
            Salary = salary;
            ReportedToEmployeeNumber = reportedToEmployeeNumber;
            VacationDaysLeft = vacationDaysLeft; // Set default value
        }

        // Parameterless constructor (required for EF Core)
        public Employee() { }

    }
}

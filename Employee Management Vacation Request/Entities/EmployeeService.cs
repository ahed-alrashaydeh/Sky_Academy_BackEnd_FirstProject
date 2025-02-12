using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_Vacation_Request.Entities
{
    public class EmployeeService
    {
        private readonly EmployeeManagementDbContext _context;

        public EmployeeService(EmployeeManagementDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            // Use LINQ to query the database
            var employees = _context.Employees
            .AsNoTracking() // Improves performance for read-only queries
            .Join(_context.Departments,
                  emp => emp.DepartmentId,
                  dept => dept.DepartmentId,
                  (emp, dept) => new EmployeeDto
                  {
                      EmployeeNumber = emp.EmployeeNumber,
                      EmployeeName = emp.EmployeeName,
                      Department = dept.DepartmentName,
                      Salary = emp.Salary
                  })
            .ToList();

            return employees;

        }

        // 2. Method to get an employee by their unique EmployeeNumber
        public EmployeeDto GetEmployeeByNumber(string employeeNumber)
        {
            // Query the database using LINQ
            var employee = (from e in _context.Employees
                            join d in _context.Departments on e.DepartmentId equals d.DepartmentId
                            join p in _context.Positions on e.PositionId equals p.PositionId
                            join r in _context.Employees on e.ReportedToEmployeeNumber equals r.EmployeeNumber into reportedTo
                            from rt in reportedTo.DefaultIfEmpty() // Left join for ReportedToEmployee
                            where e.EmployeeNumber == employeeNumber
                            select new EmployeeDto
                            {
                                EmployeeNumber = e.EmployeeNumber,
                                EmployeeName = e.EmployeeName,
                                Department = d.DepartmentName,
                                Position = p.PositionName,
                                ReportedToEmployeeName = rt != null ? rt.EmployeeName : "None", // Handle null for ReportedToEmployee
                                VacationDaysLeft = e.VacationDaysLeft
                            }).FirstOrDefault();

            return employee;
        }

        // 3. Method to get all employees with one or more pending vacation requests
        public List<EmployeeWithPendingRequestsDto> GetEmployeesWithPendingVacationRequests()
        {
            var employees = _context.Employees
                .AsNoTracking() // Improves performance for read-only queries
                .Where(emp => emp.VacationRequests.Any(vr => vr.RequestStateId == 1)) // Filter employees with pending requests
                .Select(emp => new EmployeeWithPendingRequestsDto
                {
                    EmployeeNumber = emp.EmployeeNumber,
                    EmployeeName = emp.EmployeeName,
                    Department = emp.Department.DepartmentName,
                    Position = emp.Position.PositionName,
                    PendingRequestsCount = emp.VacationRequests.Count(vr => vr.RequestStateId == 1) // Count pending requests
                })
                .ToList();

            return employees;
        }

        // 4. Method to get all approved vacation requests for a specific employee
        public List<ApprovedVacationRequestDto> GetApprovedVacationRequestsForEmployee(string employeeNumber)
        {
            var approvedRequests = _context.VacationRequests
                .AsNoTracking() // Improves performance for read-only queries
                .Where(vr => vr.EmployeeNumber == employeeNumber && vr.RequestStateId == 2) // Filter by employee and approved state
                .Select(vr => new ApprovedVacationRequestDto
                {
                    VacationType = vr.VacationType.VacationTypeName,
                    VacationDescription = vr.Description,
                    StartDate = vr.StartDate,
                    EndDate = vr.EndDate,
                    TotalVacationDays = vr.TotalVacationDays,
                    ApprovedByEmployeeName = vr.ApprovedByEmployee != null ? vr.ApprovedByEmployee.EmployeeName : "N/A"
                })
                .ToList();

            return approvedRequests;
        }

        // 5. Method to get all pending vacation requests that an employee should take action on
        public List<PendingVacationRequestDto> GetPendingVacationRequestsForAction(string reportedToEmployeeNumber)
        {
            // Fetch data from the database without calculating the duration
            var pendingRequests = _context.VacationRequests
                .AsNoTracking() // Improves performance for read-only queries
                .Where(vr => vr.Employee.ReportedToEmployeeNumber == reportedToEmployeeNumber && vr.RequestStateId == 1) // Filter by reported-to employee and pending state
                .Select(vr => new
                {
                    vr.Description,
                    vr.Employee.EmployeeNumber,
                    vr.Employee.EmployeeName,
                    vr.RequestSubmissionDate,
                    vr.StartDate,
                    vr.EndDate,
                    vr.Employee.Salary
                })
                .ToList(); // Fetch data into memory
                           // Calculate vacation duration in memory
            var result = pendingRequests.Select(vr => new PendingVacationRequestDto
            {
                VacationDescription = vr.Description,
                EmployeeNumber = vr.EmployeeNumber,
                EmployeeName = vr.EmployeeName,
                SubmittedOnDate = vr.RequestSubmissionDate,
                VacationDuration = CalculateVacationDuration(vr.StartDate, vr.EndDate), // Calculate duration in memory
                StartDate = vr.StartDate,
                EndDate = vr.EndDate,
                EmployeeSalary = vr.Salary
            })
            .ToList();

            return result;
        }
        // Helper method to calculate vacation duration in a readable format (e.g., "2 weeks", "3 days")
        private string CalculateVacationDuration(DateTime startDate, DateTime endDate)
        {
            var duration = endDate - startDate;
            int totalDays = duration.Days;

            if (totalDays >= 7)
            {
                int weeks = totalDays / 7;
                return $"{weeks} week{(weeks > 1 ? "s" : "")}";
            }
            else
            {
                return $"{totalDays} day{(totalDays > 1 ? "s" : "")}";
            }
        }

    }

}

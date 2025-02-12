using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Employee_Management_Vacation_Request.Entities
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Employee Management Vacation Request");
            Console.WriteLine("====================================");


            while (true)
            {
                // Display the menu
                //Console.WriteLine("Employee Management System");
                //Console.WriteLine();
                //Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("================");
                Console.WriteLine("Second Objective");
                Console.WriteLine("================");
                Console.WriteLine();
                Console.WriteLine("1. Add Departments");
                Console.WriteLine("2. Add Positions");
                Console.WriteLine("3. Add Employees");
                Console.WriteLine("4. Update Employee Information using Employee Number as unique key to find him/her");
                Console.WriteLine();
                Console.WriteLine("=================");
                Console.WriteLine("Thirdth Objective");
                Console.WriteLine("=================");
                Console.WriteLine();
                Console.WriteLine("5. Submit Vacation Request");
                Console.WriteLine("6. Show Pending Vacation Requests");
                Console.WriteLine();
                Console.WriteLine("================");
                Console.WriteLine("Fourth Objective");
                Console.WriteLine("================");
                Console.WriteLine();
                Console.WriteLine("7. Get all employees");
                Console.WriteLine("8. Get employee by his unique number to return data");
                Console.WriteLine("9. Get all employees have one or more pending vacation requests");
                Console.WriteLine("10. Get all history vacation requests (approved requests) for employee");
                Console.WriteLine("11. Get method to show all pending vacation requests employee should take action on");
                Console.WriteLine("12. Exit");
                Console.WriteLine("====================================");
                Console.WriteLine();
                Console.Write("Select an option: ");

                // Read user input
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Call the method to add departments
                        AddDepartments();
                        break;
                    case "2":
                        // Call the method to add positions
                        AddPositions();
                        break;
                    case "3":
                        // Call the method to add employees
                        AddEmployees();
                        break;
                    case "4":
                        UpdateEmployeeInfo();
                        break;
                    case "5":
                        SubmitVacationRequest();
                        break;
                    case "6":
                        ShowPendingVacationRequests(); 
                        break;
                    case "7":
                        DisplayAllEmployees();
                        break;
                    case "8":
                        GetAndDisplayEmployeeByNumber();
                        break;
                    case "9":
                        DisplayEmployeesWithPendingVacationRequests();
                        break;
                    case "10":
                        DisplayApprovedVacationRequestsForEmployee();
                        break;
                    case "11":
                        DisplayPendingVacationRequestsForAction();
                        break;
                    case "12":
                        Console.WriteLine("Exiting the application...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine(); // Add a blank line for readability
            }




            // /////////////////////////////////////////////// Second Objective: (CRUD Operations Using Entity Framework Core) /////////////////////////////////////////////// //



            // 1. Add method to add 20 departments

            static void AddDepartments()
            {
                using (var context = new EmployeeManagementDbContext())
                {
                    // Ensure the database is created and migrations are applied
                    context.Database.EnsureCreated();

                    // Create a list of 20 departments
                    var departments = new List<Department>
                {
                    new Department { DepartmentName = "Human Resources" },
                    new Department { DepartmentName = "Finance" },
                    new Department { DepartmentName = "Information Technology" },
                    new Department { DepartmentName = "Marketing" },
                    new Department { DepartmentName = "Sales" },
                    new Department { DepartmentName = "Research and Development" },
                    new Department { DepartmentName = "Customer Support" },
                    new Department { DepartmentName = "Operations" },
                    new Department { DepartmentName = "Legal" },
                    new Department { DepartmentName = "Procurement" },
                    new Department { DepartmentName = "Quality Assurance" },
                    new Department { DepartmentName = "Product Management" },
                    new Department { DepartmentName = "Engineering" },
                    new Department { DepartmentName = "Design" },
                    new Department { DepartmentName = "Logistics" },
                    new Department { DepartmentName = "Training and Development" },
                    new Department { DepartmentName = "Public Relations" },
                    new Department { DepartmentName = "Health and Safety" },
                    new Department { DepartmentName = "Administration" },
                    new Department { DepartmentName = "Strategic Planning" }
                };

                    // Add departments to the database
                    context.Departments.AddRange(departments);
                    context.SaveChanges();

                    Console.WriteLine("20 departments have been added to the database.");
                }
            }


            // 2. Add method to add 20 positions

            static void AddPositions()
            {
                using (var context = new EmployeeManagementDbContext())
                {
                    // Ensure the database is created and migrations are applied
                    context.Database.EnsureCreated();

                    // Create a list of 20 positions
                    var positions = new List<Position>
                {
                    new Position { PositionName = "Software Engineer" },
                    new Position { PositionName = "Senior Software Engineer" },
                    new Position { PositionName = "QA Engineer" },
                    new Position { PositionName = "DevOps Engineer" },
                    new Position { PositionName = "Product Manager" },
                    new Position { PositionName = "Project Manager" },
                    new Position { PositionName = "Data Scientist" },
                    new Position { PositionName = "Data Analyst" },
                    new Position { PositionName = "UI/UX Designer" },
                    new Position { PositionName = "Graphic Designer" },
                    new Position { PositionName = "Network Administrator" },
                    new Position { PositionName = "System Administrator" },
                    new Position { PositionName = "Database Administrator" },
                    new Position { PositionName = "Technical Support Specialist" },
                    new Position { PositionName = "Business Analyst" },
                    new Position { PositionName = "HR Manager" },
                    new Position { PositionName = "Recruiter" },
                    new Position { PositionName = "Finance Manager" },
                    new Position { PositionName = "Accountant" },
                    new Position { PositionName = "Marketing Specialist" }
                };

                    // Add positions to the database
                    context.Positions.AddRange(positions);
                    context.SaveChanges();

                    Console.WriteLine("20 positions have been added to the database.");
                }
            }


            // 3. Add method to add 10 employees

            static void AddEmployees()
            {
                using (var context = new EmployeeManagementDbContext())
                {
                    // Ensure the database is created and migrations are applied
                    context.Database.EnsureCreated();

                    // Create a list of 10 employees
                    var employees = new List<Employee>
                {
                    new Employee("E001", "John Doe", 1, 1, 'M', 5000, null), // Reports to no one
                    new Employee("E002", "Jane Smith", 2, 2, 'F', 4500, "E001"), // Reports to John Doe
                    new Employee("E003", "Alice Johnson", 3, 3, 'F', 4000, "E001"), // Reports to John Doe
                    new Employee("E004", "Bob Brown", 4, 4, 'M', 4200, "E002"), // Reports to Jane Smith
                    new Employee("E005", "Charlie Davis", 5, 5, 'M', 3800, "E002"), // Reports to Jane Smith
                    new Employee("E006", "Diana Evans", 6, 6, 'F', 4100, "E003"), // Reports to Alice Johnson
                    new Employee("E007", "Eve Foster", 7, 7, 'F', 3900, "E003"), // Reports to Alice Johnson
                    new Employee("E008", "Frank Green", 8, 8, 'M', 4300, "E004"), // Reports to Bob Brown
                    new Employee("E009", "Grace Harris", 9, 9, 'F', 4400, "E004"), // Reports to Bob Brown
                    new Employee("E010", "Hank Wilson", 10, 10, 'M', 4600, "E005") // Reports to Charlie Davis
                };

                    // Add employees to the database
                    context.Employees.AddRange(employees);
                    context.SaveChanges();

                    Console.WriteLine("10 employees have been added to the database.");
                }

            }
        }


        //4. Method to update employee main information and use employee number as unique key to find employee then update.
        
        static void UpdateEmployeeInfo()
        {
            using (var context = new EmployeeManagementDbContext())
            {
                // Prompt the user for the Employee Number
                Console.Write("Enter Employee Number to update: ");
                string employeeNumber = Console.ReadLine();

                // Find the employee by EmployeeNumber
                var employee = context.Employees
                    .FirstOrDefault(e => e.EmployeeNumber == employeeNumber);

                if (employee != null)
                {
                    // Prompt the user for updated information
                    Console.Write("Enter new Employee Name: ");
                    string newName = Console.ReadLine();

                    Console.Write("Enter new Department ID: ");
                    int newDepartmentId = int.Parse(Console.ReadLine());

                    Console.Write("Enter new Position ID: ");
                    int newPositionId = int.Parse(Console.ReadLine());

                    Console.Write("Enter new Salary: ");
                    decimal newSalary = decimal.Parse(Console.ReadLine());

                    // Update the employee's information
                    employee.EmployeeName = newName;
                    employee.DepartmentId = newDepartmentId;
                    employee.PositionId = newPositionId;
                    employee.Salary = newSalary;

                    // Save changes to the database
                    context.SaveChanges();

                    Console.WriteLine("Employee information has been updated.");
                }
                else
                {
                    Console.WriteLine($"Employee with EmployeeNumber {employeeNumber} not found.");
                }
            }
        }


        // 5. Method to update vacation days balance after approve any vacation request

        static void UpdateVacationDaysBalance(int vacationRequestId)
        {
            using (var context = new EmployeeManagementDbContext())
            {
                // Find the vacation request by ID
                var vacationRequest = context.VacationRequests
                    .Include(v => v.Employee) // Include the related Employee
                    .Include(v => v.RequestState) // Include the related RequestState
                    .FirstOrDefault(v => v.RequestId == vacationRequestId);

                if (vacationRequest != null)
                {
                    // Check if the request is approved
                    if (vacationRequest.RequestState.StateName == "Approved")
                    {
                        // Decrease the employee's vacation days left
                        vacationRequest.Employee.VacationDaysLeft -= vacationRequest.TotalVacationDays;

                        // Save changes to the database
                        context.SaveChanges();

                        Console.WriteLine($"Vacation request {vacationRequestId} has been processed. " +
                            $"Employee {vacationRequest.Employee.EmployeeName} now has {vacationRequest.Employee.VacationDaysLeft} vacation days left.");
                    }
                    else
                    {
                        Console.WriteLine($"Vacation request {vacationRequestId} is not approved.");
                    }
                }
                else
                {
                    Console.WriteLine($"Vacation request with ID {vacationRequestId} not found.");
                }
            }
        }



        // /////////////////////////////////////////////// Third Objective: Apply CRUD operation in EF core on Vacation request full cycle /////////////////////////////////////////////// //
        

        
        // 1. Method to submit a vacation request

        public static void SubmitVacationRequest()
        {
            try
            {
                // Prompt the user for input
                Console.Write("Enter Employee Number: ");
                string employeeNumber = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(employeeNumber))
                {
                    Console.WriteLine("Error: Employee number cannot be empty.");
                    return;
                }

                Console.Write("Enter Vacation Type Code (e.g., A for Annual, S for Sick): ");
                char vacationTypeCode = Console.ReadKey().KeyChar;
                Console.WriteLine(); // Move to the next line after input

                Console.Write("Enter Start Date (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
                {
                    Console.WriteLine("Error: Invalid start date format. Please use yyyy-MM-dd.");
                    return;
                }

                Console.Write("Enter End Date (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
                {
                    Console.WriteLine("Error: Invalid end date format. Please use yyyy-MM-dd.");
                    return;
                }

                // Validate date range
                if (startDate > endDate)
                {
                    Console.WriteLine("Error: Start date cannot be later than end date.");
                    return;
                }

                // Prompt for vacation description
                Console.Write("Enter Vacation Description: ");
                string description = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(description))
                {
                    Console.WriteLine("Error: Vacation description cannot be empty.");
                    return;
                }

                // Calculate total vacation days
                int totalVacationDays = (endDate - startDate).Days + 1;

                using (var context = new EmployeeManagementDbContext())
                {
                    // Check for overlapping vacations
                    bool hasOverlap = context.VacationRequests
                        .Any(v => v.EmployeeNumber == employeeNumber &&
                                 (v.StartDate <= endDate && v.EndDate >= startDate));

                    if (hasOverlap)
                    {
                        Console.WriteLine("Error: Overlapping vacation request found. Please choose different dates.");
                        return;
                    }

                    // Create a new vacation request
                    var vacationRequest = new VacationRequest
                    {
                        EmployeeNumber = employeeNumber,
                        VacationTypeCode = vacationTypeCode,
                        StartDate = startDate,
                        EndDate = endDate,
                        TotalVacationDays = totalVacationDays,
                        RequestStateId = 1, // Default state: Submitted
                        Description = description // Set the description
                    };

                    // Add the vacation request to the database
                    context.VacationRequests.Add(vacationRequest);
                    context.SaveChanges();

                    Console.WriteLine("Vacation request submitted successfully.");
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Error: Unable to save the vacation request to the database.");
                Console.WriteLine($"Details: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
                Console.WriteLine($"Details: {ex.Message}");
            }
        }


        // 2. Method to show pending vacation requests and take action

        static void ShowPendingVacationRequests()
        {
            using (var context = new EmployeeManagementDbContext())
            {
                // Retrieve all pending vacation requests
                var pendingRequests = context.VacationRequests
                    .Include(v => v.Employee) // Include the related Employee
                    .Include(v => v.RequestState) // Include the related RequestState
                    .Where(v => v.RequestState.StateName == "Submitted")
                    .ToList();

                if (pendingRequests.Any())
                {
                    Console.WriteLine("Pending Vacation Requests:");
                    foreach (var request in pendingRequests)
                    {
                        Console.WriteLine($"Request ID: {request.RequestId}, Employee: {request.Employee.EmployeeName}, " +
                            $"Start Date: {request.StartDate.ToShortDateString()}, End Date: {request.EndDate.ToShortDateString()}, " +
                            $"Total Days: {request.TotalVacationDays}");
                    }

                    // Prompt the user to take action
                    Console.Write("Enter Request ID to take action (or 0 to exit): ");
                    int requestId = int.Parse(Console.ReadLine());

                    if (requestId != 0)
                    {
                        Console.Write("Do you want to Approve (A) or Decline (D) this request? ");
                        string action = Console.ReadLine().ToUpper();

                        if (action == "A")
                        {
                            Approve(requestId);
                        }
                        else if (action == "D")
                        {
                            Decline(requestId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid action. Please try again.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No pending vacation requests found.");
                }
            }
        }

        // Method to approve a vacation request
        static void Approve(int vacationRequestId)
        {
            using (var context = new EmployeeManagementDbContext())
            {
                // Find the vacation request by ID
                var vacationRequest = context.VacationRequests
                    .Include(v => v.Employee) // Include the related Employee
                    .Include(v => v.RequestState) // Include the related RequestState
                    .FirstOrDefault(v => v.RequestId == vacationRequestId);

                if (vacationRequest != null)
                {
                    // Check if the request is in a pending state
                    if (vacationRequest.RequestState.StateName == "Submitted")
                    {
                        // Update the request state to Approved
                        vacationRequest.RequestStateId = 2; // Assuming 2 is the ID for "Approved"

                        // Deduct the vacation days from the employee's balance
                        vacationRequest.Employee.VacationDaysLeft -= vacationRequest.TotalVacationDays;

                        // Save changes to the database
                        context.SaveChanges();

                        Console.WriteLine($"Vacation request {vacationRequestId} has been approved. " +
                            $"Employee {vacationRequest.Employee.EmployeeName} now has {vacationRequest.Employee.VacationDaysLeft} vacation days left.");

                        // Call the UpdateVacationDaysBalance method
                        UpdateVacationDaysBalance(vacationRequestId);
                    }
                
                else
                {
                    Console.WriteLine($"Vacation request {vacationRequestId} is not in a pending state.");
                }
            }

                else
                {
                    Console.WriteLine($"Vacation request with ID {vacationRequestId} not found.");
                }
            }
        }

        // Method to decline a vacation request
        static void Decline(int vacationRequestId)
        {
            using (var context = new EmployeeManagementDbContext())
            {
                // Find the vacation request by ID
                var vacationRequest = context.VacationRequests
                    .Include(v => v.RequestState) // Include the related RequestState
                    .FirstOrDefault(v => v.RequestId == vacationRequestId);

                if (vacationRequest != null)
                {
                    // Check if the request is in a pending state
                    if (vacationRequest.RequestState.StateName == "Submitted")
                    {
                        // Update the request state to Declined
                        vacationRequest.RequestStateId = 3; // Assuming 3 is the ID for "Declined"

                        // Save changes to the database
                        context.SaveChanges();

                        Console.WriteLine($"Vacation request {vacationRequestId} has been declined.");
                    }
                    else
                    {
                        Console.WriteLine($"Vacation request {vacationRequestId} is not in a pending state.");
                    }
                }
                else
                {
                    Console.WriteLine($"Vacation request with ID {vacationRequestId} not found.");
                }
            }
        }




        // /////////////////////////////////////////////// Fourth Objective: use LINQ query to create get methods /////////////////////////////////////////////// //
        
        

        // 1. Method to get all employees

        public static void DisplayAllEmployees()
        {
            using (var context = new EmployeeManagementDbContext())
            {
                // Create EmployeeService
                var employeeService = new EmployeeService(context);

                // Get all employees
                var employees = employeeService.GetAllEmployees();

                // Display results
                foreach (var emp in employees)
                {
                    Console.WriteLine($"Employee Number: {emp.EmployeeNumber}, Name: {emp.EmployeeName}, Department: {emp.Department}, Salary: {emp.Salary}");
                }
            }
        }

       
        // 2. Create method to Get employee by his unique number to return data as below (check figure)

        public static void GetAndDisplayEmployeeByNumber()
        {
            Console.Write("Please enter the employee number: ");
            string employee_Number = Console.ReadLine(); // Get employee number from user input

            using (var context = new EmployeeManagementDbContext())
            {
                // Create EmployeeService
                var employeeService = new EmployeeService(context);

                // Get employee by number
                var employee = employeeService.GetEmployeeByNumber(employee_Number);

                if (employee != null)
                {
                    Console.WriteLine($"Employee Number: {employee.EmployeeNumber}");
                    Console.WriteLine($"Employee Name: {employee.EmployeeName}");
                    Console.WriteLine($"Department: {employee.Department}");
                    Console.WriteLine($"Position: {employee.Position}");
                    Console.WriteLine($"Reported To: {employee.ReportedToEmployeeName}");
                    Console.WriteLine($"Vacation Days Left: {employee.VacationDaysLeft}");
                }
                else
                {
                    Console.WriteLine($"Employee with number {employee_Number} not found.");
                }
            }
        }

       
        //3. Get all employees have one or more pending vacation requests.

        public static void DisplayEmployeesWithPendingVacationRequests()
        {
            using (var context = new EmployeeManagementDbContext())
            {
                // Create EmployeeService
                var employeeService = new EmployeeService(context);

                // Get employees with pending vacation requests
                var employees = employeeService.GetEmployeesWithPendingVacationRequests();

                // Display results
                foreach (var emp in employees)
                {
                    Console.WriteLine($"Employee Number: {emp.EmployeeNumber}");
                    Console.WriteLine($"Employee Name: {emp.EmployeeName}");
                    Console.WriteLine($"Department: {emp.Department}");
                    Console.WriteLine($"Position: {emp.Position}");
                    Console.WriteLine($"Pending Requests: {emp.PendingRequestsCount}");
                    Console.WriteLine("-----------------------------");
                }
            }
        }

       
        // 4. Get all history vacation requests (approved requests) for employee.

        public static void DisplayApprovedVacationRequestsForEmployee()
        {
            // Prompt the user to enter the employee number
            Console.Write("Enter Employee Number: ");
            string employeeNumber = Console.ReadLine();

            using (var context = new EmployeeManagementDbContext())
            {
                // Create EmployeeService
                var employeeService = new EmployeeService(context);

                // Get approved vacation requests for the specified employee
                var approvedRequests = employeeService.GetApprovedVacationRequestsForEmployee(employeeNumber);

                // Display results
                if (approvedRequests != null && approvedRequests.Any())
                {
                    Console.WriteLine($"Approved Vacation Requests for Employee {employeeNumber}:");
                    foreach (var request in approvedRequests)
                    {
                        Console.WriteLine($"Vacation Type: {request.VacationType}");
                        Console.WriteLine($"Description: {request.VacationDescription}");
                        Console.WriteLine($"Start Date: {request.StartDate.ToShortDateString()}");
                        Console.WriteLine($"End Date: {request.EndDate.ToShortDateString()}");
                        Console.WriteLine($"Total Vacation Days: {request.TotalVacationDays}");
                        Console.WriteLine($"Approved By: {request.ApprovedByEmployeeName}");
                        Console.WriteLine("-----------------------------");
                    }
                }
                else
                {
                    Console.WriteLine($"No approved vacation requests found for employee with number {employeeNumber}.");
                }
            }
        }


        // 5. Get method to show all pending vacation requests employee should take action on.

        public static void DisplayPendingVacationRequestsForAction()
        {
            // Prompt the user to enter the reported-to employee number
            Console.Write("Enter Reported-To Employee Number: ");
            string reportedToEmployeeNumber = Console.ReadLine();

            using (var context = new EmployeeManagementDbContext())
            {
                // Create EmployeeService
                var employeeService = new EmployeeService(context);

                // Get pending vacation requests for the specified employee to approve
                var pendingRequests = employeeService.GetPendingVacationRequestsForAction(reportedToEmployeeNumber);

                // Display results
                if (pendingRequests != null && pendingRequests.Any())
                {
                    Console.WriteLine($"Pending Vacation Requests for Employee {reportedToEmployeeNumber} to Approve:");
                    foreach (var request in pendingRequests)
                    {
                        Console.WriteLine($"Description: {request.VacationDescription}");
                        Console.WriteLine($"Employee Number: {request.EmployeeNumber}");
                        Console.WriteLine($"Employee Name: {request.EmployeeName}");
                        Console.WriteLine($"Submitted On: {request.SubmittedOnDate.ToShortDateString()}");
                        Console.WriteLine($"Vacation Duration: {request.VacationDuration}");
                        Console.WriteLine($"Start Date: {request.StartDate.ToShortDateString()}");
                        Console.WriteLine($"End Date: {request.EndDate.ToShortDateString()}");
                        Console.WriteLine($"Employee Salary: {request.EmployeeSalary:C}");
                        Console.WriteLine("-----------------------------");
                    }
                }
                else
                {
                    Console.WriteLine($"No pending vacation requests found for employee with number {reportedToEmployeeNumber} to approve.");
                }
            }
        }
    }
}
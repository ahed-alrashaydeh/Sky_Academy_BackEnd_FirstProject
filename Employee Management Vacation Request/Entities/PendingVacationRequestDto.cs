using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Vacation_Request.Entities
{
    public class PendingVacationRequestDto
    {
        public string VacationDescription { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public DateTime SubmittedOnDate { get; set; }
        public string VacationDuration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal EmployeeSalary { get; set; }

    }
}

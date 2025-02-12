using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Vacation_Request.Entities
{
    public class EmployeeDto
    {
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public string ReportedToEmployeeName { get; set; }
        public int VacationDaysLeft { get; set; }


    }
}

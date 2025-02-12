using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Vacation_Request.Entities
{
    public class ApprovedVacationRequestDto
    {
        public string VacationType { get; set; }
        public string VacationDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalVacationDays { get; set; }
        public string ApprovedByEmployeeName { get; set; }

    }
}

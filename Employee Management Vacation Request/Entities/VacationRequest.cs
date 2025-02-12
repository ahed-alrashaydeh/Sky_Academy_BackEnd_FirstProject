using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Vacation_Request.Entities
{
    // VacationRequest Entity
    public class VacationRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Identity column
        public int RequestId { get; set; } // Primary Key, Identity

        [Required]
        public DateTime RequestSubmissionDate { get; set; } // Required, DateTime

        [Required]
        [MaxLength(100)]
        public string Description { get; set; } // Required, Max 100 characters

        [Required]
        [MaxLength(6)]
        public required string EmployeeNumber { get; set; } // Foreign Key to Employee

        [Required]
        [MaxLength(1)]
        public char VacationTypeCode { get; set; } // Foreign Key to VacationType

        [Required]
        [Column(TypeName = "date")] // Store only the date (no time)
        public DateTime StartDate { get; set; } // Required, Date only

        [Required]
        [Column(TypeName = "date")] // Store only the date (no time)
        public DateTime EndDate { get; set; } // Required, Date only

        [Required]
        public int TotalVacationDays { get; set; } // Required, Integer

        [Required]
        public int RequestStateId { get; set; } // Foreign Key to RequestState

        [MaxLength(6)]
        public string? ApprovedByEmployeeNumber { get; set; } // Nullable, Foreign Key to Employee

        [MaxLength(6)]
        public string? DeclinedByEmployeeNumber { get; set; } // Nullable, Foreign Key to Employee

        // Navigation property to Employee (who submitted the request)
        [ForeignKey("EmployeeNumber")]
        public Employee Employee { get; set; }

        // Navigation property to VacationType
        [ForeignKey("VacationTypeCode")]
        public VacationType VacationType { get; set; }

        // Navigation property to RequestState
        [ForeignKey("RequestStateId")]
        public RequestState RequestState { get; set; }

        // Navigation property to Employee (who approved the request)
        [ForeignKey("ApprovedByEmployeeNumber")]
        public Employee ApprovedByEmployee { get; set; }

        // Navigation property to Employee (who declined the request)
        [ForeignKey("DeclinedByEmployeeNumber")]
        public Employee DeclinedByEmployee { get; set; }
    }
}

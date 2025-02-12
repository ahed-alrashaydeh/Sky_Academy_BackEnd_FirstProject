using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Vacation_Request.Entities
{
    // Request State Entity
    public class RequestState
    {
        [Key]
        public int StateId { get; set; } // Primary Key, Unique ID

        [Required]
        [MaxLength(10)]
        public required string StateName { get; set; } // Required, Max 10 characters

        // Navigation property for VacationRequests in this state
        // Property establishes a one-to-many relationship between two entities.
        // In this case, it would allow a RequestState to have multiple VacationRequest records associated with it.
        public ICollection<VacationRequest> VacationRequests { get; set; } = new List<VacationRequest>();
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Vacation_Request.Entities
{
    // VacationType Entity
    public class VacationType
    {
        [Key]
        [MaxLength(1)]
        public char VacationTypeCode { get; set; } // Primary Key, Max 1 character

        [Required]
        [MaxLength(20)]
        public string VacationTypeName { get; set; } // Required, Max 20 characters

        // Navigation property for VacationRequests of this type
        // Property is a navigation property that establishes a one-to-many relationship between two entities.
        // In this case, it would allow a VacationType to have multiple VacationRequest records associated with it.
        public ICollection<VacationRequest> VacationRequests { get; set; } = new List<VacationRequest>();
    }

}

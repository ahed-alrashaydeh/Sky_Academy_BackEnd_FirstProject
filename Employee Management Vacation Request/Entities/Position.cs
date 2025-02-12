using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Vacation_Request.Entities
{
    // Position Entity
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Identity column
        public int PositionId { get; set; } // Primary Key, Identity

        [Required]
        [MaxLength(30)]
        public string PositionName { get; set; } // Required, Max 30 characters

        // Navigation property for Employees in this Position

        // Property establishes a one-to-many relationship between two entities.
        // In this case, it would allow a Position to have multiple Employee records associated with it. 
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }

}

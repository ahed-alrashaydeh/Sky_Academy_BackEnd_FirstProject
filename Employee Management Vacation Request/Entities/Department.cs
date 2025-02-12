using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management_Vacation_Request.Entities
{
    // Department Entity
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Identity column
        public int DepartmentId { get; set; } // Primary Key, Identity

        [Required]
        [MaxLength(50)]
        public string DepartmentName { get; set; } // Required, Max 50 characters

        // Navigation property for Employees in this Department

        // This establishes a one-to-many relationship between the Department and Employee entities,
        // meaning one department can have multiple employees.
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }

}

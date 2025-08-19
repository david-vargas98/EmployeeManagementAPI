using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public String Phone { get; set; }

        [Required(ErrorMessage = "Position is required")]
        public String Position { get; set; }
    }
}

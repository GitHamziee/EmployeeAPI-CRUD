using System.ComponentModel.DataAnnotations;

namespace APICRUD.Models.Entities
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Email { get; set; }
     
        public  string? Phone { get; set; }
        public decimal Salary { get; set; }
    }
}

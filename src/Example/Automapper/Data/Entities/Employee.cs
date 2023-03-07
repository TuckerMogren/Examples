using System.ComponentModel.DataAnnotations;
using Data.Interfaces;

namespace Data.Models
{

    public class Employee : IEmployee
    {
        [Required]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Salary { get; set; }
        public string? Address { get; set; }
        public string? Department { get; set; }   
    }
}


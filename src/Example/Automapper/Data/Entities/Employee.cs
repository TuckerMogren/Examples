using System.ComponentModel.DataAnnotations;
using Data.Interfaces;

namespace Data.Models
{

    public class Employee : IEmployee
    {
        [Key]
        public int? ID { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public int? Salary { get; set; }
        public string? Address { get; set; }
        public string? Department { get; set; }   
    }
}


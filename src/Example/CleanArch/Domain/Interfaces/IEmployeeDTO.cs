using System;
namespace Domain.Interfaces
{
    public interface IEmployeeDTO
    {

        public string? FullName { get; set; }
        public int? Salary { get; set; }
        public string? Address { get; set; }
        public string? Dept { get; set; }

    }

}



using System;
using Domain.Interfaces;


namespace Domain.DTOModels
{
	public class EmployeeDTO : IEmployeeDTO
    {

        public string? FullName { get; set; }
        public int? Salary { get; set; }
        public string? Address { get; set; }
        public string? Dept { get; set; }
    }
}


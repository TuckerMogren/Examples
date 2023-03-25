using System;
namespace Data.Interfaces;

public interface IEmployee
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? Salary { get; set; }
    public string? Address { get; set; }
    public string? Department { get; set; }
}


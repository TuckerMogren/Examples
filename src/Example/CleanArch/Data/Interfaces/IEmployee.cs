using System;
namespace Data.Interfaces;

public interface IEmployee
{
    public int? ID { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public int? Salary { get; set; }
    public string? Address { get; set; }
    public string? Department { get; set; }
}


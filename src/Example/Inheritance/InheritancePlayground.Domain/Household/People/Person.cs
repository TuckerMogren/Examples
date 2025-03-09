// Person.cs
namespace InheritancePlayground.Domain;

using System;

public class Person(string Name, int Age) : BaseEntity
{
    public string Name { get; set; } = Name;
    public int Age { get; set; } = Age;
    public bool IsAlive { get; set; } = true;
}
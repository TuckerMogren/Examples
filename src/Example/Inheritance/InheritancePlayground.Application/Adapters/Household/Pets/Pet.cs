using System;

namespace InheritancePlayground.Application.Adapters.Household.Pets;

public class Pet(string Name, int Age) : Animal ( Age)
{
    public string Name { get; set; } = Name;
}

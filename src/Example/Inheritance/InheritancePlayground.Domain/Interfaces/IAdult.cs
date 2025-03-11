using System;

namespace InheritancePlayground.Domain.Interfaces;

public interface IAdult : ISessionBase
{
    string Name { get; }
    string Occupation { get; }
    bool HasSpouse { get; }
    bool HasChildren { get; }
}

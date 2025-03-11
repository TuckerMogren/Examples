using System;

namespace InheritancePlayground.Domain.Interfaces;

public interface IPet : ISessionBase
{
    string Name { get; }
}

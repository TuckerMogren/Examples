using System;

namespace InheritancePlayground.Domain.Interfaces;

public interface IDog : ISessionBase
{
    string FavoriteToy { get; }
}

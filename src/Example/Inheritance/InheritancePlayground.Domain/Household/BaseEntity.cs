// BaseEntity.cs
namespace InheritancePlayground.Domain;

using System;

public abstract class BaseEntity
{
    protected internal Guid Id { get; set; } = Guid.NewGuid(); // Ensuring IDs are always initialized
}
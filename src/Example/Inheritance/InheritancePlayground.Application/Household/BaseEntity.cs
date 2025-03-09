namespace InheritancePlayground.Application.Household
{
    using System;

    public abstract class BaseEntity
    {
        protected internal Guid Id { get; set; } = Guid.NewGuid(); // Ensuring IDs are always initialized
    }
}
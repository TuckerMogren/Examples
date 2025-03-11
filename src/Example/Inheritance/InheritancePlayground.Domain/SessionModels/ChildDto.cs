using InheritancePlayground.Domain.Interfaces;

namespace InheritancePlayground.Domain.SessionModels;

public class ChildDto : IChild
{
    public string Name { get; set; } = string.Empty;
}

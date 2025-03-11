using InheritancePlayground.Domain.Interfaces;

namespace InheritancePlayground.Domain.SessionModels;

public class PetDto : IPet
{
    public string Name { get; set; } = string.Empty;
}

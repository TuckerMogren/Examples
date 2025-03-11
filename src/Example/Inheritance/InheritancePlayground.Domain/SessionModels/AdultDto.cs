using InheritancePlayground.Domain.Interfaces;

namespace InheritancePlayground.Domain.SessionModels;

public class AdultDto : IAdult
{
    public string Name { get; set; } = string.Empty;

    public string Occupation { get; set; } = string.Empty;

    public bool HasSpouse { get; set; }

    public bool HasChildren { get; set; }
}

using InheritancePlayground.Domain.SessionModels;

namespace InheritancePlayground.Domain.Interfaces;

public interface IHouseholdDto : ISessionBase
{
    IReadOnlyCollection<HomeDto> Homes { get; }
    IReadOnlyCollection<AdultDto> Adults { get; }
    IReadOnlyCollection<ChildDto> Children { get; }
    IReadOnlyCollection<PetDto> Pets { get; }
}

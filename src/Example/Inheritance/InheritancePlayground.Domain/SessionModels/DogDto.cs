using InheritancePlayground.Domain.Interfaces;

namespace InheritancePlayground.Domain.SessionModels;

public class DogDto : IDog
{
    public string FavoriteToy { get; set; } = string.Empty;
}

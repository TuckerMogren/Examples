// Dog.cs
namespace InheritancePlayground.Domain.Household.Pets
{
    public class Dog : Animal
    {
        public string Name { get; set; } = string.Empty;
        public string FavoriteToy { get; set; } = string.Empty;
    }
}
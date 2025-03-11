namespace InheritancePlayground.Application.Adapters.Household.Pets
{
    public class Dog(string Name, int Age, string FavoriteToy) : Pet (Name, Age)
    {
        public string FavoriteToy { get; set; } = FavoriteToy;
        public override string Species 
        { 
            get => "Canis familiaris";
        }

    }
}
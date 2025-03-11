namespace InheritancePlayground.Application.Adapters.Household.Pets
{
    public class Animal(int Age) : BaseEntity
    {
        public virtual string Species { get; set; } = string.Empty;
        public int Age { get; set; } = Age;
    }
}

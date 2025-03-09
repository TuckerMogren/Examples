namespace InheritancePlayground.Application.Household.Pets
{
    public class Animal : BaseEntity
    {
        public string Species { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}

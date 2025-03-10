using System.Collections.ObjectModel;
using InheritancePlayground.Application.Household.House;

namespace InheritancePlayground.Application.Household.People
{
    public class Person(string name, int age) : BaseEntity
    {
        private readonly List<Home>? _homes;

        public Person(string name, int age, List<Home>? homes) : this(name, age)
        {
            _homes = homes;
        }

        public string Name { get; set; } = name;
        public int Age { get; set; } = age;
        public bool IsAlive { get; set; } = true;

        public IReadOnlyCollection<Home> Homes => new ReadOnlyCollection<Home>(_homes ?? []);
    }
}

namespace InheritancePlayground.domain.Household.People
{

    public class Adult(string Name, int Age) : Person(Name, Age)
    {
        protected Guid? SpouseId { get; set; }
        public string? Occupation { get; set; } = string.Empty;
        public bool HasChildren => _children.Count != 0;
        public bool HasSpouse => SpouseId != null;
        private readonly List<Child> _children = new();
        public IReadOnlyList<Child> Children => _children.AsReadOnly();

        public void AddChild(Child child)
        {
            if (!_children.Contains(child))
            {
                _children.Add(child);
            }
        }

        protected Child? GetChild(Guid childId)
        {
            return _children.FirstOrDefault(x => x.Id == childId);
        }

        /// <summary>
        /// No Polygamy allowed, I applogize. Will set the spouse Id in both spouses by just calling one.
        /// </summary>
        /// <param name="SpouseId"></param>
        public void AddSpouse(Adult Spouse)
        {
            SpouseId = Spouse.Id;
            Spouse.SpouseId = Id;
        }

        /// <summary>
        /// Will divorce for both spouses.
        /// </summary>
        /// <param name="Spouse"></param>
        public void RemoveSpouse(Adult Spouse)
        {
            SpouseId = null;
            Spouse.SpouseId = null;
        }
    }
}
namespace InheritancePlayground.Application.Household.People
{
    public class Child : Person
    {
        private bool _isStillChild = true;

        public bool IsStillChild 
        {
            get => _isStillChild;
            set => _isStillChild = value;
        }

        private readonly List<Adult> _parents;

        public void AddParent(Adult adult)
        {
            _parents.Add(adult);
        }

        public void RemoveParent(Adult Parent)
        {
            _parents.Remove(Parent); 
        }

        protected Adult? GetParent(Guid parentId)
        {
            return _parents.FirstOrDefault(p => p.Id == parentId);
        }

        public Child(string Name, int Age, List<Adult> Parents) : base(Name, Age)
        {
            _parents = Parents;

            foreach(var parent in Parents)
            {
                parent.AddChild(this);
            }
        }
    }
}
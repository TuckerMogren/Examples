namespace InheritancePlayground.Domain;

public class Person(string Name, int Age) : BaseEntity
{
    public string Name { get; set; } = Name;
    public int Age { get; set; } = Age;
    public bool IsAlive { get; set; } = true;
}

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

public class Adult(string Name, int Age) : Person(Name, Age)
{
    protected Guid? SpouseId { get; set; }
    public string? Occupation { get; set; } = string.Empty;
    public bool HasChildren => _children.Count != 0;
    public bool HasSpouse => SpouseId != null;
    private readonly List<Child> _children = [];
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
        this.SpouseId = Spouse.Id;
        Spouse.SpouseId = this.Id;
    }

    /// <summary>
    /// Will divorce for both spouses.
    /// </summary>
    /// <param name="Spouse"></param>
    public void RemoveSpouse(Adult Spouse)
    {
        this.SpouseId = null;
        Spouse.SpouseId = null;
    }
}

public class Dog : Animal
{
    public string Name { get; set; } = string.Empty;
    public string FavoriteToy { get; set; } = string.Empty;
}

public class Animal : BaseEntity
{
    public string Species { get; set; } = string.Empty;
    public int Age { get; set; }
}

public abstract class BaseEntity
{
    protected internal Guid Id { get; set; } = Guid.NewGuid(); // Ensuring IDs are always initialized
}
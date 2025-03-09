namespace InheritancePlayground.Domain;

public class Person(string Name, int Age) : BaseEntity
{
    public string Name { get; set; } = Name;
    public int Age { get; set; } = Age;
    public bool IsAlive { get; set; } = true;
}

public class Child(string Name, int Age) : Person(Name, Age)
{
    public bool IsStillChild { get; set; }
    private readonly List<Adult> _parents = [];

    public void AddParent(Adult adult)
    {
        _parents.Add(adult);
    }

    protected Adult? GetParent(Guid parentId)
    {
        return _parents.FirstOrDefault(p => p.Id == parentId);
    }
}

public class Adult(string Name, int Age) : Person(Name, Age)
{
    protected Guid? SpouseId { get; set; }
    public string? Occupation { get; set; } = string.Empty;
    public bool HasChildren => _children.Count != 0;
    private List<Child> _children = [];

    public void AddChild(Child child)
    {
        _children.Add(child);
    }

    protected Child? GetChild(Guid childId)
    {
        return _children.FirstOrDefault(x => x.Id == childId);
    }

    /// <summary>
    /// No Polygamy allowed, I applogize.
    /// </summary>
    /// <param name="SpouseId"></param>
    public void AddSpouse(Adult Spouse)
    {
        this.SpouseId = Spouse.Id;
    }

    public void RemoveSpouse()
    {
        this.SpouseId = null;
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
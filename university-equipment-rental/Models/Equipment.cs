namespace university_equipment_rental.Models;

public abstract class Equipment
{
    private static int _nextId = 1;

    public int Id { get; }
    public string Name { get; set; }
    public bool IsAvailable { get; set; }
    public string Condition { get; set; }

    protected Equipment(string name, string condition)
    {
        Id = _nextId++;
        Name = name;
        Condition = condition;
        IsAvailable = true;
    }

    public override string ToString()
    {
        return $"{Id}: {Name} | Available: {IsAvailable} | Condition: {Condition}";
    }
}
namespace university_equipment_rental.Models;

public abstract class User
{
    private static int _nextId = 1;

    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public abstract string UserType { get; }
    public abstract int RentalLimit { get; }

    protected User(string firstName, string lastName)
    {
        Id = _nextId++;
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"{Id}: {FirstName} {LastName} | Type: {UserType}";
    }
}
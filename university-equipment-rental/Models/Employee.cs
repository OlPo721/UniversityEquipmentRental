namespace university_equipment_rental.Models;

public class Employee : User
{
    public string Department { get; set; }

    public Employee(string firstName, string lastName, string department)
        : base(firstName, lastName)
    {
        Department = department;
    }

    public override string UserType => "Employee";
    public override int RentalLimit => 5;
}
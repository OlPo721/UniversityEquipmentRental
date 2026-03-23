namespace university_equipment_rental.Models;

public class Student : User
{
    public string StudentNumber { get; set; }

    public Student(string firstName, string lastName, string studentNumber)
        : base(firstName, lastName)
    {
        StudentNumber = studentNumber;
    }

    public override string UserType => "Student";
    public override int RentalLimit => 2;
}
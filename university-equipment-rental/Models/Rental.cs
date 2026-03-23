namespace university_equipment_rental.Models;

public class Rental
{
    public User User { get; }
    public Equipment Equipment { get; }
    public DateTime RentalDate { get; }
    public int RentalDurationDays { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }
    public decimal Penalty { get; private set; }

    public bool IsReturned => ReturnDate.HasValue;
    public bool WasReturnedOnTime => IsReturned && ReturnDate!.Value.Date <= DueDate.Date;
    public bool IsOverdue => !IsReturned && DateTime.Now.Date > DueDate.Date;

    public Rental(User user, Equipment equipment, DateTime rentalDate, int rentalDurationDays)
    {
        User = user;
        Equipment = equipment;
        RentalDate = rentalDate;
        RentalDurationDays = rentalDurationDays;
        DueDate = rentalDate.AddDays(rentalDurationDays);
    }

    public void Return(DateTime returnDate, decimal penalty)
    {
        ReturnDate = returnDate;
        Penalty = penalty;
    }

    public override string ToString()
    {
        string returnInfo = ReturnDate.HasValue ? ReturnDate.Value.ToShortDateString() : "Not returned";
        string onTimeInfo = ReturnDate.HasValue ? WasReturnedOnTime.ToString() : "N/A";

        return $"{User.FirstName} {User.LastName} rented {Equipment.Name} on {RentalDate:d} " +
               $"for {RentalDurationDays} days, due {DueDate:d}, returned: {returnInfo}, " +
               $"on time: {onTimeInfo}, penalty: {Penalty}";
    }
}
namespace university_equipment_rental.Services;

public class RentalPolicyService
{
    public bool CanUserRent(int activeRentalsCount, int rentalLimit)
    {
        return activeRentalsCount < rentalLimit;
    }

    public decimal CalculatePenalty(DateTime dueDate, DateTime returnDate)
    {
        if (returnDate.Date <= dueDate.Date)
        {
            return 0;
        }

        int lateDays = (returnDate.Date - dueDate.Date).Days;
        return lateDays * 10m;
    }
}
using university_equipment_rental.Models;

namespace university_equipment_rental.Services;

public class ReportService
{
    public void PrintEquipmentReport(IEnumerable<Equipment> equipmentItems)
    {
        Console.WriteLine("=== EQUIPMENT REPORT ===");
        foreach (var item in equipmentItems)
        {
            Console.WriteLine(item);
        }
    }

    public void PrintRentalReport(IEnumerable<Rental> rentals)
    {
        Console.WriteLine("=== RENTAL REPORT ===");
        foreach (var rental in rentals)
        {
            Console.WriteLine(rental);
        }
    }

    public void PrintSummaryReport(IEnumerable<Equipment> equipmentItems, IEnumerable<Rental> rentals)
    {
        int totalEquipment = equipmentItems.Count();
        int availableEquipment = equipmentItems.Count(e => e.IsAvailable);
        int unavailableEquipment = equipmentItems.Count(e => !e.IsAvailable);

        int activeRentals = rentals.Count(r => !r.IsReturned);
        int overdueRentals = rentals.Count(r => r.IsOverdue);
        decimal totalPenalties = rentals.Sum(r => r.Penalty);

        Console.WriteLine("=== SUMMARY REPORT ===");
        Console.WriteLine($"Total equipment items: {totalEquipment}");
        Console.WriteLine($"Available equipment: {availableEquipment}");
        Console.WriteLine($"Unavailable equipment: {unavailableEquipment}");
        Console.WriteLine($"Active rentals: {activeRentals}");
        Console.WriteLine($"Overdue rentals: {overdueRentals}");
        Console.WriteLine($"Total penalties: {totalPenalties}");
    }
}
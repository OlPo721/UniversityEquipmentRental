using university_equipment_rental.Models;

namespace university_equipment_rental.Data;

public class AppRepository
{
    public List<User> Users { get; } = new();
    public List<Equipment> EquipmentItems { get; } = new();
    public List<Rental> Rentals { get; } = new();
}
using university_equipment_rental.Data;
using university_equipment_rental.Models;

namespace university_equipment_rental.Services;

public class RentalService
{
    private readonly AppRepository _repository;
    private readonly RentalPolicyService _rentalPolicyService;

    public RentalService(AppRepository repository, RentalPolicyService rentalPolicyService)
    {
        _repository = repository;
        _rentalPolicyService = rentalPolicyService;
    }

    public void AddUser(User user)
    {
        _repository.Users.Add(user);
    }

    public void AddEquipment(Equipment equipment)
    {
        _repository.EquipmentItems.Add(equipment);
    }

    public IEnumerable<Equipment> GetAllEquipment()
    {
        return _repository.EquipmentItems;
    }

    public IEnumerable<Equipment> GetAvailableEquipment()
    {
        return _repository.EquipmentItems.Where(e => e.IsAvailable);
    }

    public Rental RentEquipment(int userId, int equipmentId, int days)
    {
        User? user = _repository.Users.FirstOrDefault(u => u.Id == userId);
        Equipment? equipment = _repository.EquipmentItems.FirstOrDefault(e => e.Id == equipmentId);

        if (user == null)
            throw new InvalidOperationException("User not found.");

        if (equipment == null)
            throw new InvalidOperationException("Equipment not found.");

        if (!equipment.IsAvailable)
            throw new InvalidOperationException("Equipment is not available.");

        int activeRentals = _repository.Rentals.Count(r => r.User.Id == userId && !r.IsReturned);

        if (!_rentalPolicyService.CanUserRent(activeRentals, user.RentalLimit))
            throw new InvalidOperationException("User exceeded rental limit.");

        var rental = new Rental(user, equipment, DateTime.Now.Date, days);
        equipment.IsAvailable = false;
        _repository.Rentals.Add(rental);

        return rental;
    }

    public decimal ReturnEquipment(int equipmentId, DateTime returnDate)
    {
        Rental? rental = _repository.Rentals
            .FirstOrDefault(r => r.Equipment.Id == equipmentId && !r.IsReturned);

        if (rental == null)
            throw new InvalidOperationException("Active rental not found.");

        decimal penalty = _rentalPolicyService.CalculatePenalty(rental.DueDate, returnDate);
        rental.Return(returnDate, penalty);
        rental.Equipment.IsAvailable = true;

        return penalty;
    }

    public void MarkEquipmentUnavailable(int equipmentId)
    {
        Equipment? equipment = _repository.EquipmentItems.FirstOrDefault(e => e.Id == equipmentId);

        if (equipment == null)
            throw new InvalidOperationException("Equipment not found.");

        equipment.IsAvailable = false;
    }

    public IEnumerable<Rental> GetActiveRentalsForUser(int userId)
    {
        return _repository.Rentals.Where(r => r.User.Id == userId && !r.IsReturned);
    }

    public IEnumerable<Rental> GetOverdueRentals()
    {
        return _repository.Rentals.Where(r => r.IsOverdue);
    }

    public IEnumerable<Rental> GetAllRentals()
    {
        return _repository.Rentals;
    }
}
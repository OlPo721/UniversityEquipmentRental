using university_equipment_rental.Data;
using university_equipment_rental.Models;
using university_equipment_rental.Services;

var repository = new AppRepository();
var rentalPolicyService = new RentalPolicyService();
var rentalService = new RentalService(repository, rentalPolicyService);
var reportService = new ReportService();

// Add users
var student = new Student("Anna", "Kowalska", "s12345");
var employee = new Employee("Jan", "Nowak", "IT");

rentalService.AddUser(student);
rentalService.AddUser(employee);

// Add equipment
var laptop = new Laptop("Dell Latitude", "Good", 16, "Intel i7");
var projector = new Projector("Epson X1", "Very good", 3200, "1920x1080");
var camera = new Camera("Canon EOS", "Good", 24, true);

rentalService.AddEquipment(laptop);
rentalService.AddEquipment(projector);
rentalService.AddEquipment(camera);

// Display full list of equipment
Console.WriteLine("\n=== FULL EQUIPMENT LIST ===");
reportService.PrintEquipmentReport(rentalService.GetAllEquipment());

// Display only available equipment
Console.WriteLine("\n=== AVAILABLE EQUIPMENT BEFORE RENTALS ===");
reportService.PrintEquipmentReport(rentalService.GetAvailableEquipment());

// Correct rental
Console.WriteLine("\n=== CORRECT RENTAL ===");
var rental1 = rentalService.RentEquipment(student.Id, laptop.Id, 7);
Console.WriteLine(rental1);

// Invalid rental: same equipment already rented
Console.WriteLine("\n=== INVALID RENTAL ===");
try
{
    rentalService.RentEquipment(employee.Id, laptop.Id, 3);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

// On-time return
Console.WriteLine("\n=== ON-TIME RETURN ===");
decimal penalty1 = rentalService.ReturnEquipment(laptop.Id, rental1.DueDate);
Console.WriteLine($"Penalty: {penalty1}");

// Delayed return with penalty
Console.WriteLine("\n=== LATE RETURN ===");
var rental2 = rentalService.RentEquipment(employee.Id, projector.Id, 5);
decimal penalty2 = rentalService.ReturnEquipment(projector.Id, rental2.DueDate.AddDays(3));
Console.WriteLine($"Penalty: {penalty2}");

// Mark equipment unavailable
Console.WriteLine("\n=== MARK CAMERA UNAVAILABLE ===");
rentalService.MarkEquipmentUnavailable(camera.Id);

// Active rentals for selected user
Console.WriteLine("\n=== ACTIVE RENTALS FOR EMPLOYEE ===");
reportService.PrintRentalReport(rentalService.GetActiveRentalsForUser(employee.Id));

// Overdue rentals
Console.WriteLine("\n=== OVERDUE RENTALS ===");
reportService.PrintRentalReport(rentalService.GetOverdueRentals());

// Final full report
Console.WriteLine("\n=== FINAL EQUIPMENT REPORT ===");
reportService.PrintEquipmentReport(rentalService.GetAllEquipment());

Console.WriteLine("\n=== FINAL RENTAL REPORT ===");
reportService.PrintRentalReport(rentalService.GetAllRentals());

Console.WriteLine("\n=== FINAL SUMMARY REPORT ===");
reportService.PrintSummaryReport(rentalService.GetAllEquipment(), rentalService.GetAllRentals());
# University Equipment Rental

Console application in C# for managing a university equipment rental service.

## Project description
The system supports:
- adding users,
- adding equipment,
- listing all equipment,
- listing only available equipment,
- renting equipment,
- returning equipment with penalty calculation,
- marking equipment as unavailable,
- showing active rentals for a selected user,
- showing overdue rentals,
- generating a summary report.

## Project structure
- `Models` contains domain objects such as `Equipment`, `User`, and `Rental`.
- `Data` contains `AppRepository`, which stores application data in memory.
- `Services` contains business logic and reporting logic.
- `Program.cs` contains only the demonstration scenario.

## Design decisions
The code is divided into separate folders to keep responsibilities clear.
- Domain classes are placed in `Models`.
- Business logic is placed in `Services`.
- Data storage is placed in `Data`.
- `Program.cs` is used only to run the scenario.

This improves readability and reduces coupling between classes.
Penalty rules and rental limits are placed in a dedicated service, so they are easier to modify in one place.

## Run instruction
Run the project with:

## Notes
The project was written as a simple console application, so the main goal was to keep the code readable and divide responsibilities between models, services, and the repository.

```bash
dotnet run
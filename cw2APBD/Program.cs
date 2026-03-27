// See https://aka.ms/new-console-template for more information

using cw2APBD.Domain;
using cw2APBD.Domain.Equipment;
using cw2APBD.Domain.Users;
using cw2APBD.Repos;
using cw2APBD.Service;
using cw2APBD.Service.Interfaces;

var equipmentRepo = new EquipmentRepository();
var userRepo = new UserRepository();
var rentalRepo = new RentalRepository();

IEquipmentService equipmentService = new EquipmentService(equipmentRepo);
IUserService userService = new UserService(userRepo, rentalRepo);
IRentalService rentalService = new RentalService(rentalRepo, equipmentService, userService);

//equipment
Laptop laptop = new Laptop("Dell XPS 15", 2200, "Intel i7", 16);
Projector projector = new Projector("Epson EB-2250", 800, 3500, "1080p");
Camera camera = new Camera("Canon EOS 90D", 1000, "CMOS", 10);

equipmentService.AddEquipment(laptop);
equipmentService.AddEquipment(projector);
equipmentService.AddEquipment(camera);
Console.WriteLine($"Added: {laptop.Name}, {projector.Name}, {camera.Name}");

//users
Student student = new Student("John", "Doe", "aaaa", "Bachelor", "CS");
Employee employee = new Employee("Jane", "Doe", "aaaa", "IT", 5000, null);

userService.AddUser(student);
userService.AddUser(employee);
Console.WriteLine($"Added: {student.GetFullName()} (Student, max 2 rentals)");
Console.WriteLine($"Added: {employee.GetFullName()} (Employee, max 5 rentals)");

//rental
Console.WriteLine("correct rental");
Rental rental1 = rentalService.RentEquipment(student, laptop, 7);
Console.WriteLine($"   {student.GetFullName()} rented {laptop.Name} for 7 days");

Console.WriteLine("incorrect");

//renting unavailable equipment
try
{
    rentalService.RentEquipment(employee, laptop, 3);
    Console.WriteLine("Should have failed");
}
catch (Exception ex)
{
    Console.WriteLine($"Blocked: {ex.Message}");
}

//exceeding student limit
try
{
    rentalService.RentEquipment(student, projector, 5);
    rentalService.RentEquipment(student, camera, 3);
    Console.WriteLine("Should have failed :c");
}
catch (Exception ex)
{
    Console.WriteLine($"Blocked: {ex.Message}\n");
}

//return
Console.WriteLine("return");
Rental returned = rentalService.ReturnEquipment(rental1.Id);
Console.WriteLine($"   {returned.RentedEquipment.Name} returned on time");
Console.WriteLine($"   Late fee: ${returned.Fee:F2}\n");

//return with penalty
Console.WriteLine("return penalty");
Rental lateRental = rentalService.RentEquipment(employee, camera, -2);
Console.WriteLine($"{employee.GetFullName()} rented {camera.Name}");
Console.WriteLine($"Due: {lateRental.ExpectedReturnDate:d}");

Rental returnedLate = rentalService.ReturnEquipment(lateRental.Id);

Console.WriteLine($"Returned: {returnedLate.ReturnDate:d}");
Console.WriteLine($"Days overdue: {returnedLate.DaysOverdue()}");
Console.WriteLine($"Late fee: ${returnedLate.Fee:F2}\n");

Console.WriteLine("report");
Console.WriteLine($"Equipment: {equipmentService.GetAllEquipment().Count} total, {equipmentService.GetAvailableEquipment().Count} available");
Console.WriteLine($"Users: {userService.GetAllUsers().Count}");
Console.WriteLine($"Rentals: {rentalService.GetAllRentals().Count} total, {rentalService.GetOverdueRentals().Count} overdue");
Console.WriteLine($"Total fees collected: ${rentalService.GetAllRentals().Sum(r => r.Fee)}");
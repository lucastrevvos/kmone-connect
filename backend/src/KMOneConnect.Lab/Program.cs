using KMOneConnect.Domain.Entities;
using KMOneConnect.Domain.ValueObjects;

var documentNumber = new DocumentNumber("23255432502");

var ownerDriver = new Driver(
    fullName: "Lucas Amaral",
    documentNumber: documentNumber,
    phoneNumber: "119999999"
);

ownerDriver.Verify();

var plate = new Plate("abc1d23");

var vehicle = new Vehicle(
    ownerDriverId: ownerDriver.Id,
    brand: "Ford",
    model: "Ka",
    year: 2019,
    plate: plate
);

var dailyRate = Money.InBrl(120);
var depositAmount = Money.InBrl(500);

var availablePeriod = new RentalPeriod(
    startDate: new DateOnly(2026, 6, 15),
    endDate: new DateOnly(2026, 6, 20)
);

var offer = new RentalOffer(
    vehicleId: vehicle.Id,
    ownerDriverId: ownerDriver.Id,
    dailyRate: dailyRate,
    depositAmount: depositAmount,
    availablePeriod: availablePeriod
);

Console.WriteLine("KM One Connect — Domain Lab");
Console.WriteLine("----------------------------");

Console.WriteLine("Driver");
Console.WriteLine($"Id: {ownerDriver.Id}");
Console.WriteLine($"Name: {ownerDriver.FullName}");
Console.WriteLine($"Document: {ownerDriver.DocumentNumber}");
Console.WriteLine($"Phone: {ownerDriver.PhoneNumber}");
Console.WriteLine($"Is Verified: {ownerDriver.IsVerified}");
Console.WriteLine($"Is Active: {ownerDriver.IsActive}");

Console.WriteLine();

Console.WriteLine("Vehicle");
Console.WriteLine($"Id: {vehicle.Id}");
Console.WriteLine($"Owner Driver Id: {vehicle.OwnerDriverId}");
Console.WriteLine($"Display Name: {vehicle.GetDisplayName()}");
Console.WriteLine($"Plate: {vehicle.Plate}");
Console.WriteLine($"Is Available: {vehicle.IsAvailable}");

Console.WriteLine();

Console.WriteLine("KM One Connect — Rental Offer Lab");
Console.WriteLine("---------------------------------");
Console.WriteLine($"Offer Id: {offer.Id}");
Console.WriteLine($"Vehicle Id: {offer.VehicleId}");
Console.WriteLine($"Owner Driver Id: {offer.OwnerDriverId}");
Console.WriteLine($"Daily Rate: {offer.DailyRate:C}");
Console.WriteLine($"Deposit Amount: {offer.DepositAmount:C}");
Console.WriteLine($"Available Period: {offer.AvailablePeriod}");
Console.WriteLine($"Total Days: {offer.AvailablePeriod.TotalDays}");
Console.WriteLine($"Is Active: {offer.IsActive}");
Console.WriteLine($"Total Amount: {offer.CalculateTotal()}");

Console.WriteLine();
Console.WriteLine("Activating offer...");
offer.Activate();
vehicle.MarkAsUnavailable();

Console.WriteLine($"Status: {offer.Status}");
Console.WriteLine($"Is Active: {offer.IsActive}");
Console.WriteLine($"Vehicle Is Available: {vehicle.IsAvailable}");

Console.WriteLine();
Console.WriteLine("Pausing offer...");
offer.Pause();

Console.WriteLine($"Status: {offer.Status}");
Console.WriteLine($"Is Active: {offer.IsActive}");

Console.WriteLine();
Console.WriteLine("Activating again...");
offer.Activate();

Console.WriteLine($"Status: {offer.Status}");
Console.WriteLine($"Is Active: {offer.IsActive}");

Console.WriteLine();
Console.WriteLine("Closing offer...");
offer.Close();

Console.WriteLine($"Status: {offer.Status}");
Console.WriteLine($"Is Active: {offer.IsActive}");

/*Console.WriteLine();
Console.WriteLine("Trying to activate closed offer...");
offer.Activate();
*/

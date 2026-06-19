using KMOneConnect.Domain.ValueObjects;
namespace KMOneConnect.Domain.Entities;

public class Vehicle
{
    public Guid Id { get; private set; }
    public Guid OwnerDriverId { get; private set; }
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public int Year { get; private set; }
    public Plate Plate { get; private set; }
    public bool IsAvailable { get; private set; }

    public Vehicle(
        Guid ownerDriverId,
        string brand,
        string model,
        int year,
        Plate plate)
    {
        if (ownerDriverId == Guid.Empty)
            throw new ArgumentException("OwnerDriverId is required.");

        if (string.IsNullOrWhiteSpace(brand))
            throw new ArgumentException("Brand is required.");

        if (string.IsNullOrWhiteSpace(model))
            throw new ArgumentException("Model is required.");

        if (year < 1990)
            throw new ArgumentException("Vehicle year is invalid.");

        Id = Guid.NewGuid();
        OwnerDriverId = ownerDriverId;
        Brand = brand.Trim();
        Model = model.Trim();
        Year = year;
        Plate = plate;
        IsAvailable = true;
    }

    public void MarkAsUnavailable()
    {
        IsAvailable = false;
    }

    public string GetDisplayName()
    {
        return $"{Brand} {Model} {Year}";
    }
}

using KMOneConnect.Domain.ValueObjects;
using KMOneConnect.Domain.Enums;

namespace KMOneConnect.Domain.Entities;

public class RentalOffer
{
    public Guid Id { get; private set; }
    public Guid VehicleId { get; private set; }
    public Guid OwnerDriverId { get; private set; }
    public Money DailyRate { get; private set; }
    public Money DepositAmount { get; private set; }
    public RentalPeriod AvailablePeriod { get; private set; }
    public RentalOfferStatus Status { get; private set; }
    public bool IsActive => Status == RentalOfferStatus.Active;

    public RentalOffer(
        Guid vehicleId,
        Guid ownerDriverId,
        Money dailyRate,
        Money depositAmount,
        RentalPeriod availablePeriod)
    {
        if (vehicleId == Guid.Empty)
            throw new ArgumentException("VehicleId is required.");

        if (ownerDriverId == Guid.Empty)
            throw new ArgumentException("OwnerDriver is required.");

        if (dailyRate.Amount <= 0)
            throw new ArgumentException("Daily rate must be greater than zero.");

        VehicleId = vehicleId;
        OwnerDriverId = ownerDriverId;
        DailyRate = dailyRate;
        DepositAmount = depositAmount;
        AvailablePeriod = availablePeriod;
        Id = Guid.NewGuid();
        Status = RentalOfferStatus.Draft;
    }

    public void Activate()
    {
        if (Status == RentalOfferStatus.Closed)
            throw new InvalidOperationException("Cannot activate a closed rental offer.");

        if (Status == RentalOfferStatus.Active)
            return;

        Status = RentalOfferStatus.Active;
    }

    public void Pause()
    {
        if (Status != RentalOfferStatus.Active)
            throw new InvalidOperationException("Only active rental offers can be paused.");

        Status = RentalOfferStatus.Paused;
    }

    public void Close()
    {
        if (Status == RentalOfferStatus.Closed)
            return;

        Status = RentalOfferStatus.Closed;
    }

    public Money CalculateTotal()
    {
        var rentalAmount = DailyRate.Multiply(AvailablePeriod.TotalDays);

        return rentalAmount.Add(DepositAmount);
    }

}

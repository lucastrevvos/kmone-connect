namespace KMOneConnect.Domain.ValueObjects;

public sealed record RentalPeriod
{
    public DateOnly StartDate { get; }
    public DateOnly EndDate { get; }

    public int TotalDays => EndDate.DayNumber - StartDate.DayNumber + 1;

    public RentalPeriod(DateOnly startDate, DateOnly endDate)
    {
        if (endDate < startDate)
            throw new ArgumentException("End date cannot be before start date.");

        StartDate = startDate;
        EndDate = endDate;
    }

    public bool Contains(DateOnly date)
    {
        return date >= StartDate && date <= EndDate;
    }

    public override string ToString()
    {
        return $"{StartDate:dd/MM/yyyy} - {EndDate:dd/MM/yyyy}";
    }
}

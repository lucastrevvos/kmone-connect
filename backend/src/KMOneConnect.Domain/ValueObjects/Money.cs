namespace KMOneConnect.Domain.ValueObjects;

public sealed record Money
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency = "BRL")
    {
        if (amount < 0)
            throw new ArgumentException("Money amount cannot be negative.");

        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentNullException("Currency is required");

        Amount = amount;
        Currency = currency.ToUpperInvariant();
    }

    public static Money InBrl(decimal amount)
    {
        return new Money(amount, "BRL");
    }

    public Money Add(Money other)
    {
        EnsureSameCurrency(other);

        return new Money(Amount + other.Amount, Currency);
    }

    public Money Multiply(int multiplier)
    {
        if (multiplier < 0)
            throw new ArgumentException("Multiplier cannot be negative.");

        return new Money(Amount * multiplier, Currency);
    }

    private void EnsureSameCurrency(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException("Cannot operate with different currencies.");
    }

    public override string ToString()
    {
        return $"{Currency} {Amount:N2}";
    }
}

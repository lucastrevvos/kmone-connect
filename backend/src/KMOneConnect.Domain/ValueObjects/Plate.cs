using System.Text.RegularExpressions;

namespace KMOneConnect.Domain.ValueObjects;
public sealed record Plate
{
    public string Value { get; }

    public Plate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Plate is required.");

        var normalizedValue = value
            .Trim()
            .Replace("-", "")
            .Replace(" ", "")
            .ToUpperInvariant();

        if (normalizedValue.Length != 7)
            throw new ArgumentException("Plate must have 7 characters.");

        if (!Regex.IsMatch(normalizedValue, @"^[A-Z]{3}[0-9][A-Z0-9][0-9]{2}$"))
            throw new ArgumentException("Plate format is invalid.");

        Value = normalizedValue;
    }

    public override string ToString()
    {
        return $"{Value[..3]}-{Value[3..]}";
    }
}

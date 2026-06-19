namespace KMOneConnect.Domain.ValueObjects;

public sealed record DocumentNumber
{
    public string Value { get; }

    public DocumentNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Document number is required.");

        var normalizedValue = value
            .Trim()
            .Replace(".", "")
            .Replace("-", "")
            .Replace("/", "")
            .Replace(" ", "");

        if (normalizedValue.Length != 11 && normalizedValue.Length != 14)
            throw new ArgumentException("Document number must have 11 or 14 digits.");

        if (!normalizedValue.All(char.IsDigit))
            throw new ArgumentException("Document number must contain only digits");

        if (HasAllSameDigits(normalizedValue))
            throw new ArgumentException("Document number is invalid.");

        Value = normalizedValue;
    }

    public bool IsCpf => Value.Length == 11;

    public bool IsCnpj => Value.Length == 14;

    private static bool HasAllSameDigits(string value)
    {
        return value.All(character => character == value[0]);
    }

    public override string ToString()
    {
        if (IsCpf)
            return $"{Value[..3]}.{Value[3..6]}.{Value[6..9]}-{Value[9..]}";

        return $"{Value[..2]}.{Value[2..5]}.{Value[5..8]}/{Value[8..12]}-{Value[12..]}";
    }
}

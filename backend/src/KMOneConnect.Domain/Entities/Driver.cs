using KMOneConnect.Domain.ValueObjects;

namespace KMOneConnect.Domain.Entities;

public class Driver
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public DocumentNumber DocumentNumber { get; private set; }
    public string PhoneNumber { get; private set; }
    public bool IsVerified { get; private set; }
    public bool IsActive { get; private set; }

    public Driver(
        string fullName,
        DocumentNumber documentNumber,
        string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Full name is required.");

        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone number is required.");

        Id = Guid.NewGuid();
        FullName = fullName.Trim();
        DocumentNumber = documentNumber;
        PhoneNumber = phoneNumber.Trim();
        IsVerified = false;
        IsActive = true;
    }

    public void Verify()
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot verify an inactive driver.");

        IsVerified = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void ChangePhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone number is required.");

        PhoneNumber = phoneNumber.Trim();
    }

}

using EduSubscription.Core.Members.Enumerations;
using EduSubscription.Primitives;

namespace EduSubscription.Core.Members;

public class Member : Entity
{
    public Member(string firstName, string lastName, string documentNumber, string email, ERole role, bool isActive)
    {
        FirstName = firstName;
        LastName = lastName;
        DocumentNumber = documentNumber;
        Email = email;
        Role = role;
        IsActive = isActive;
    }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string DocumentNumber { get; private set; }
    public string Email { get; private set; }
    public ERole Role { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(string firstName, string lastName, string documentNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        DocumentNumber = documentNumber;
    }
    
}
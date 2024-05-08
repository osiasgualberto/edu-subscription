namespace EduSubscription.Application.Members.Views;

public class MemberViewModel
{
    public MemberViewModel(Guid id, string firstName, string lastName, string documentNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        DocumentNumber = documentNumber;
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DocumentNumber { get; set; }
}
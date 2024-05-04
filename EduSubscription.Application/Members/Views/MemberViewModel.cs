﻿namespace EduSubscription.Application.Members.Views;

public class MemberViewModel
{
    public MemberViewModel(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
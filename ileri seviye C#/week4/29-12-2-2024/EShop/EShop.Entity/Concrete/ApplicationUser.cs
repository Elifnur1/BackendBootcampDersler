using System;
using EShop.Shared.ComplexType;
using Microsoft.AspNetCore.Identity;

namespace EShop.Entity.Concrete;

public class ApplicationUser : IdentityUser
{
    private ApplicationUser()
    {

    }
    public ApplicationUser(string firstName, string lastName, DateTime dateofBirth, GenderType gender)
    {
        FirstName = firstName;
        LastName = lastName;
        DateofBirth = dateofBirth;
        Gender = gender;
    }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? City { get; set; }
    public DateTime DateofBirth { get; set; }
    public GenderType Gender { get; set; }
}

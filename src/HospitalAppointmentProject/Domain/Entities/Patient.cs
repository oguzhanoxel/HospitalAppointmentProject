using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Patient : Entity<int>
{
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Email { get; set; }
	public string? Phone { get; set; }

    public Patient()
    {
        
    }

	public Patient(int id, string firstName, string lastName, string email, string phone) : base(id)
	{
		FirstName = firstName;
		LastName = lastName;
		Email = email;
		Phone = phone;
	}
}

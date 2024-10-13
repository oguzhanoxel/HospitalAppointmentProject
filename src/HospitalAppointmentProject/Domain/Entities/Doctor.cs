using Core.Persistence.Repositories;

namespace Domain.Entities;

public enum Branch
{
	Cardiology,
	Neurology,
	Pediatrics,
	GeneralPractice,
	Orthopedics
}

public class Doctor : Entity<int>
{
	public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
	public Branch Branch { get; set; }

	public Doctor()
	{

	}

	public Doctor(int id, string firstName, string lastName, string email, string phone, Branch branch) : base(id)
	{
		FirstName = firstName;
		LastName = lastName;
		Email = email;
		Phone = phone;
		Branch = branch;
	}
}

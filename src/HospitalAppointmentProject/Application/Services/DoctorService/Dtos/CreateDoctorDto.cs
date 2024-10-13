using Domain.Entities;

namespace Application.Services.DoctorService.Dtos;

public class CreateDoctorDto
{
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Email { get; set; }
	public string? Phone { get; set; }
	public Branch Branch { get; set; }
}

using Domain.Entities;

namespace Application.Services.DoctorService.Dtos;

public class ResponseDoctorDto
{
	public int Id { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Email { get; set; }
	public string? Phone { get; set; }
	public Branch Branch { get; set; }
}

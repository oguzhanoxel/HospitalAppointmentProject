namespace Application.Services.PatientService.Dtos;

public class CreatePatientDto
{
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Email { get; set; }
	public string? Phone { get; set; }
}

namespace Application.Services.AppointmentService.Dtos;

public class ResponseAppointmentDetailsDto
{
	public int Id { get; set; }
	public DateTime Date { get; set; }

    public int DoctorId { get; set; }
    public string? DoctorFirstName { get; set; }
	public string? DoctorLastName { get; set; }
	public string? DoctorEmail { get; set; }
	public string? DoctorPhone { get; set; }
	public string DoctorBranchName { get; set; }

    public int PatientId { get; set; }
    public string? PatientFirstName { get; set; }
	public string? PatientLastName { get; set; }
	public string? PatientEmail { get; set; }
	public string? PatientPhone { get; set; }
}


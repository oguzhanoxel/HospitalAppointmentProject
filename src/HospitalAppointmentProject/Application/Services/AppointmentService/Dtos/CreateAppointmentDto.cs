namespace Application.Services.AppointmentService.Dtos;

public class CreateAppointmentDto
{
	public DateTime Date { get; set; }
	public int DoctorId { get; set; }
	public int PatientId { get; set; }
}

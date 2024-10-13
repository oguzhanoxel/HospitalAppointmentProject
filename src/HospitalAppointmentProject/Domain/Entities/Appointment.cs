using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Appointment : Entity<int>
{
    public DateTime Date { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }

    public Appointment()
    {
        
    }

	public Appointment(int id, DateTime date, int doctorId, int patientId) : base(id)
	{
		Date = date;
		DoctorId = doctorId;
		PatientId = patientId;
	}
}

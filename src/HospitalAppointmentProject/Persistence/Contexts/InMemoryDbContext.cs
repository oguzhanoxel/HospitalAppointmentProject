using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class InMemoryDbContext : DbContext
{
	private const string DatabaseName = "MyBeautifulDB";

	public InMemoryDbContext(DbContextOptions options) : base(options)
    {
        
    }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
        optionsBuilder.UseInMemoryDatabase("MyBeautifulDB");
	}

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Doctor>()
			.HasIndex(d => d.Email)
			.IsUnique();

		modelBuilder.Entity<Appointment>()
			.HasOne(a => a.Doctor)
			.WithMany()
			.HasForeignKey(a => a.DoctorId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Appointment>()
			.HasOne(a => a.Patient)
			.WithMany()
			.HasForeignKey(a => a.PatientId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<Doctor>().HasData(
			new Doctor(1, "Jotaro", "Kujo", "jotaro.kujo@jojo.com", "1234567890", Branch.GeneralPractice),
			new Doctor(2, "Joseph", "Joestar", "joseph.joestar@jojo.com", "0987654321", Branch.Cardiology),
			new Doctor(3, "Dio", "Brando", "dio.brando@jojo.com", "0001112222", Branch.Neurology)
		);

		modelBuilder.Entity<Patient>().HasData(
			new Patient { Id = 1, FirstName = "Josuke", LastName = "Higashikata", Email = "josuke.higashikata@jojo.com", Phone = "1112223333" },
			new Patient { Id = 2, FirstName = "Giorno", LastName = "Giovanna", Email = "giorno.giovanna@jojo.com", Phone = "2223334444" },
			new Patient { Id = 3, FirstName = "Jolyne", LastName = "Cujoh", Email = "jolyne.cujoh@jojo.com", Phone = "3334445555" },
			new Patient { Id = 4, FirstName = "Narancia", LastName = "Ghirga", Email = "narancia.ghirga@jojo.com", Phone = "4445556666" },
			new Patient { Id = 5, FirstName = "Trish", LastName = "Una", Email = "trish.una@jojo.com", Phone = "5556667777" },
			new Patient { Id = 6, FirstName = "Rohan", LastName = "Kishibe", Email = "rohan.kishibe@jojo.com", Phone = "6667778888" },
			new Patient { Id = 7, FirstName = "Koichi", LastName = "Hirose", Email = "koichi.hirose@jojo.com", Phone = "7778889999" },
			new Patient { Id = 8, FirstName = "Enrico", LastName = "Pucci", Email = "enrico.pucci@jojo.com", Phone = "8889990000" },
			new Patient { Id = 9, FirstName = "Mista", LastName = "Guido", Email = "mista.guido@jojo.com", Phone = "9990001111" },
			new Patient { Id = 10, FirstName = "Rizotto", LastName = "Neri", Email = "rizotto.neri@jojo.com", Phone = "1010101010" },
			new Patient { Id = 11, FirstName = "Weather", LastName = "Report", Email = "weather.report@jojo.com", Phone = "2221113333" }
		);

		modelBuilder.Entity<Appointment>().HasData(
			new Appointment(1, new DateTime(2024, 10, 5, 10, 0, 0), 1, 1),
			new Appointment(2, new DateTime(2024, 10, 8, 11, 0, 0), 1, 2),
			new Appointment(3, new DateTime(2024, 10, 10, 9, 30, 0), 1, 3),
			new Appointment(4, new DateTime(2024, 10, 10, 13, 0, 0), 1, 4),
			new Appointment(5, new DateTime(2024, 10, 12, 14, 0, 0), 1, 5),

			new Appointment(6, new DateTime(2024, 10, 15, 10, 0, 0), 1, 6),
			new Appointment(7, new DateTime(2024, 10, 17, 11, 0, 0), 1, 7),
			new Appointment(8, new DateTime(2024, 10, 18, 12, 0, 0), 1, 8),
			new Appointment(9, new DateTime(2024, 10, 20, 9, 30, 0), 1, 9),

			new Appointment(10, new DateTime(2024, 10, 15, 10, 0, 0), 2, 1),
			new Appointment(11, new DateTime(2024, 10, 16, 11, 0, 0), 2, 2),
			new Appointment(12, new DateTime(2024, 10, 17, 12, 0, 0), 2, 3),

			new Appointment(13, new DateTime(2024, 10, 5, 10, 0, 0), 3, 4),
			new Appointment(14, new DateTime(2024, 10, 8, 11, 0, 0), 3, 5),
			new Appointment(15, new DateTime(2024, 10, 10, 9, 30, 0), 3, 6),
			new Appointment(16, new DateTime(2024, 10, 10, 13, 0, 0), 3, 7),
			new Appointment(17, new DateTime(2024, 10, 12, 14, 0, 0), 3, 8),
			new Appointment(18, new DateTime(2024, 10, 15, 10, 0, 0), 3, 9),
			new Appointment(19, new DateTime(2024, 10, 17, 12, 0, 0), 3, 10)
		);
	}
}

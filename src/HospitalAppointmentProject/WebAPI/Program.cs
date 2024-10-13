using Application.Services.AppointmentService;
using Application.Services.DoctorService;
using Application.Services.PatientService;
using Application.Services.Repositories;
using Persistence.Contexts;
using Persistence.Repositories;

namespace WebAPI;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
		builder.Services.AddScoped<IPatientRepository, PatientRepository>();
		builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

		builder.Services.AddScoped<IDoctorService, DoctorService>();
		builder.Services.AddScoped<IPatientService, PatientService>();
		builder.Services.AddScoped<IAppointmentService, AppointmentService>();

		builder.Services.AddDbContext<InMemoryDbContext>();



		var app = builder.Build();

		using (var scope = app.Services.CreateScope())
		{
			var dbContext = scope.ServiceProvider.GetRequiredService<InMemoryDbContext>();
			dbContext.Database.EnsureCreated();
		}

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();


		app.MapControllers();

		app.Run();
	}
}

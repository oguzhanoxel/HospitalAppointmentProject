using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AppointmentRepository : EfRepositoryBase<InMemoryDbContext, Appointment>, IAppointmentRepository
{
	public AppointmentRepository(InMemoryDbContext context) : base(context)
	{

	}
}
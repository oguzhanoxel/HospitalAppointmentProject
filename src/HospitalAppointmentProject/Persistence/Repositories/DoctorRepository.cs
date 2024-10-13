using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;
public class DoctorRepository : EfRepositoryBase<InMemoryDbContext, Doctor>, IDoctorRepository
{
	public DoctorRepository(InMemoryDbContext context) : base(context)
	{
	
	}
}

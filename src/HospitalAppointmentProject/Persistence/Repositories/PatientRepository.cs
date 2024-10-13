using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PatientRepository : EfRepositoryBase<InMemoryDbContext, Patient>, IPatientRepository
{
	public PatientRepository(InMemoryDbContext context) : base(context) 
	{

	}
}

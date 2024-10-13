using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IDoctorRepository : IRepository<Doctor, int>
{

}

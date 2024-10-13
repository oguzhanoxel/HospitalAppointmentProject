using Application.Services.DoctorService.Dtos;
using Core.Application.Results.Abstracts;
using Domain.Entities;

namespace Application.Services.DoctorService;

public interface IDoctorService
{
	public IResult Create(CreateDoctorDto doctor);
	public IResult Update(UpdateDoctorDto doctor);
	public IResult Delete(DeleteDoctorDto doctor);
	public IDataResult<List<ResponseDoctorDto>> GetAll();
	public IDataResult<ResponseDoctorDto> GetById(int id);
}

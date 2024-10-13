using Application.Services.PatientService.Dtos;
using Core.Application.Results.Abstracts;
using Domain.Entities;

namespace Application.Services.PatientService;

public interface IPatientService
{
	public IResult Create(CreatePatientDto patient);
	public IResult Update(UpdatePatientDto patient);
	public IResult Delete(DeletePatientDto patient);
	public IDataResult<List<ResponsePatientDto>> GetAll();
	public IDataResult<ResponsePatientDto> GetById(int id);
}

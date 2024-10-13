using Application.Services.PatientService.Dtos;
using Application.Services.Repositories;
using Core.Application.Results.Abstracts;
using Core.Application.Results.Concretes;
using Domain.Entities;

namespace Application.Services.PatientService;

public class PatientService : IPatientService
{
	private readonly IPatientRepository _repository;

	public PatientService(IPatientRepository repository)
	{
		_repository = repository;
	}

	public IResult Create(CreatePatientDto patient)
	{
		var mappedPatient = new Patient
		{
			FirstName = patient.FirstName,
			LastName = patient.LastName,
			Email = patient.Email,
			Phone = patient.Phone
		};

		_repository.Create(mappedPatient);
		return Result.SuccessResult("Patient created successfully.");
	}

	public IResult Delete(DeletePatientDto patient)
	{
		var tempPatient = _repository.Get(p => p.Id == patient.Id);
		if (tempPatient == null) return Result.FailureResult("Patient not found.");

		_repository.Delete(tempPatient);
		return Result.SuccessResult("Patient deleted successfully.");
	}

	public IDataResult<List<ResponsePatientDto>> GetAll()
	{
		var patients = _repository.GetAll()
			.Select(p => new ResponsePatientDto
			{
				Id = p.Id,
				FirstName = p.FirstName,
				LastName = p.LastName,
				Email = p.Email,
				Phone = p.Phone
			}).ToList();

		return DataResult<List<ResponsePatientDto>>.Success(patients, "Patients retrieved successfully.");
	}

	public IDataResult<ResponsePatientDto> GetById(int id)
	{
		var patient = _repository.Get(p => p.Id == id);
		if (patient == null)
		{
			return DataResult<ResponsePatientDto>.Failure("Patient not found.");
		}

		var response = new ResponsePatientDto
		{
			Id = patient.Id,
			FirstName = patient.FirstName,
			LastName = patient.LastName,
			Email = patient.Email,
			Phone = patient.Phone
		};

		return DataResult<ResponsePatientDto>.Success(response, "Patient retrieved successfully.");
	}

	public IResult Update(UpdatePatientDto patient)
	{
		var tempPatient = _repository.Get(p => p.Id == patient.Id);
		if (tempPatient == null)
		{
			return Result.FailureResult("Patient not found.");
		}

		tempPatient.FirstName = patient.FirstName;
		tempPatient.LastName = patient.LastName;
		tempPatient.Email = patient.Email;
		tempPatient.Phone = patient.Phone;

		_repository.Update(tempPatient);
		return Result.SuccessResult("Patient updated successfully.");
	}
}

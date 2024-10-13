using Application.Services.DoctorService.Dtos;
using Application.Services.Repositories;
using Core.Application.Results.Abstracts;
using Core.Application.Results.Concretes;
using Domain.Entities;

namespace Application.Services.DoctorService;

public class DoctorService : IDoctorService
{
	private readonly IDoctorRepository _repository;

    public DoctorService(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public IResult Create(CreateDoctorDto doctor)
	{
		Doctor mappedDoctor = new Doctor
		{
			FirstName = doctor.FirstName,
			LastName = doctor.LastName,
			Email = doctor.Email,
			Phone = doctor.Phone,
			Branch = doctor.Branch
		};

		_repository.Create(mappedDoctor);
		return Result.SuccessResult("Doctor created successfully.");
	}

	public IResult Delete(DeleteDoctorDto doctor)
	{
		var tempDoctor = _repository.Get(d => d.Id == doctor.Id);
		if (tempDoctor == null) return Result.FailureResult("Doctor not found.");

		_repository.Delete(tempDoctor);
		return Result.SuccessResult("Doctor deleted successfully.");
	}

	public IDataResult<List<ResponseDoctorDto>> GetAll()
	{
		var doctors = _repository.GetAll()
			.Select(d => new ResponseDoctorDto
			{
				Id = d.Id,
				FirstName = d.FirstName,
				LastName = d.LastName,
				Email = d.Email,
				Phone = d.Phone,
				Branch = d.Branch
			}).ToList();

		return DataResult<List<ResponseDoctorDto>>.Success(doctors, "Doctors retrieved successfully.");
	}

	public IDataResult<ResponseDoctorDto> GetById(int id)
	{
		var doctor = _repository.Get(d => d.Id == id);
		if (doctor == null)
		{
			return DataResult<ResponseDoctorDto>.Failure("Doctor not found.");
		}

		var response = new ResponseDoctorDto
		{
			Id = doctor.Id,
			FirstName = doctor.FirstName,
			LastName = doctor.LastName,
			Email = doctor.Email,
			Phone = doctor.Phone,
			Branch = doctor.Branch
		};

		return DataResult<ResponseDoctorDto>.Success(response, "Doctor retrieved successfully.");
	}

	public IResult Update(UpdateDoctorDto doctor)
	{
		var tempDoctor = _repository.Get(d => d.Id == doctor.Id);
		if (tempDoctor == null)
		{
			return Result.FailureResult("Doctor not found.");
		}

		tempDoctor.FirstName = doctor.FirstName;
		tempDoctor.LastName = doctor.LastName;
		tempDoctor.Email = doctor.Email;
		tempDoctor.Phone = doctor.Phone;
		tempDoctor.Branch = doctor.Branch;

		_repository.Update(tempDoctor);
		return Result.SuccessResult("Doctor updated successfully.");
	}
}

using Application.Services.AppointmentService.Dtos;
using Application.Services.DoctorService;
using Application.Services.Repositories;
using Core.Application.Results.Abstracts;
using Core.Application.Results.Concretes;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.AppointmentService;

public class AppointmentService : IAppointmentService
{
	private readonly IAppointmentRepository _repository;
	private readonly IDoctorService _doctorService;

	public AppointmentService(IAppointmentRepository repository, IDoctorService doctorService)
	{
		_repository = repository;
		_doctorService = doctorService;
	}

	public IResult Create(CreateAppointmentDto appointment)
	{
		var validationErrors = ValidateCreateAppointmentDto(appointment);
		if (validationErrors.Any())
		{
			var errorMessage = string.Join(", ", validationErrors);
			return Result.FailureResult($"Validation failed: {errorMessage}");
		}

		var mappedAppointment = new Appointment
		{
			Date = appointment.Date,
			DoctorId = appointment.DoctorId,
			PatientId = appointment.PatientId
		};

		_repository.Create(mappedAppointment);
		return Result.SuccessResult("Appointment created successfully.");
	}

	public IResult Delete(DeleteAppointmentDto appointment)
	{
		var tempAppointment = _repository.Get(a => a.Id == appointment.Id);
		if (tempAppointment == null)
		{
			return Result.FailureResult("Appointment not found.");
		}

		_repository.Delete(tempAppointment);
		return Result.SuccessResult("Appointment deleted successfully.");
	}

	public IResult DeleteExpiredAppointments()
	{
		DateTime today = DateTime.Now;
		var expiredAppointments = _repository.GetAll(a => a.Date < today);
		if (!expiredAppointments.Any())
		{
			return Result.FailureResult("Expired Appointments not found.");
		}

		expiredAppointments.ForEach(appointment => {
			_repository.Delete(appointment);
		});

		return Result.SuccessResult("Expired Appointments deleted successfully.");
	}

	public IDataResult<List<ResponseAppointmentDto>> GetAll()
	{
		var appointments = _repository.GetAll()
			.Select(a => new ResponseAppointmentDto
			{
				Id = a.Id,
				Date = a.Date,
				DoctorId = a.DoctorId,
				PatientId = a.PatientId
			}).ToList();

		return DataResult<List<ResponseAppointmentDto>>.Success(appointments, "Appointments retrieved successfully.");
	}

	public IDataResult<List<ResponseAppointmentDetailsDto>> GetAllDetails()
	{
		var appointments = _repository.GetAll(
			include: a => a.Include(d => d.Doctor)
						   .Include(p => p.Patient))
						.Select(appointment => new ResponseAppointmentDetailsDto
						{
							Id = appointment.Id,
							Date = appointment.Date,

							DoctorId = appointment.DoctorId,
							DoctorFirstName = appointment.Doctor.FirstName,
							DoctorLastName = appointment.Doctor.LastName,
							DoctorEmail = appointment.Doctor.Email,
							DoctorPhone = appointment.Doctor.Phone,
							DoctorBranchName = appointment.Doctor.Branch.ToString(),

							PatientId = appointment.PatientId,
							PatientFirstName = appointment.Patient.FirstName,
							PatientLastName = appointment.Patient.LastName,
							PatientEmail = appointment.Patient.Email,
							PatientPhone = appointment.Patient.Phone,
						}).ToList();

		return DataResult<List<ResponseAppointmentDetailsDto>>.Success(appointments, "Appointments retrieved successfully.");
	}

	public IDataResult<List<ResponseAppointmentDetailsDto>> GetAllDetailsByDoctorId(int doctorId)
	{
		var appointments = _repository.GetAll(
			a => a.DoctorId == doctorId,
			include: a => a.Include(d => d.Doctor)
						   .Include(p => p.Patient))
						.Select(appointment => new ResponseAppointmentDetailsDto
						{
							Id = appointment.Id,
							Date = appointment.Date,

							DoctorId = appointment.DoctorId,
							DoctorFirstName = appointment.Doctor.FirstName,
							DoctorLastName = appointment.Doctor.LastName,
							DoctorEmail = appointment.Doctor.Email,
							DoctorPhone = appointment.Doctor.Phone,
							DoctorBranchName = appointment.Doctor.Branch.ToString(),

							PatientId = appointment.PatientId,
							PatientFirstName = appointment.Patient.FirstName,
							PatientLastName = appointment.Patient.LastName,
							PatientEmail = appointment.Patient.Email,
							PatientPhone = appointment.Patient.Phone,
						}).ToList();

		return DataResult<List<ResponseAppointmentDetailsDto>>.Success(appointments, "Appointments retrieved successfully.");
	}

	public IDataResult<ResponseAppointmentDto> GetById(int id)
	{
		var appointment = _repository.Get(a => a.Id == id);
		if (appointment == null)
		{
			return DataResult<ResponseAppointmentDto>.Failure("Appointment not found.");
		}

		var response = new ResponseAppointmentDto
		{
			Id = appointment.Id,
			Date = appointment.Date,
			DoctorId = appointment.DoctorId,
			PatientId = appointment.PatientId
		};

		return DataResult<ResponseAppointmentDto>.Success(response, "Appointment retrieved successfully.");
	}

	public IDataResult<ResponseAppointmentDetailsDto> GetDetailsById(int id)
	{
		var appointment = _repository.Get(
			a => a.Id == id,
			include: a => a.Include(d => d.Doctor)
						   .Include(p => p.Patient));

		if (appointment == null)
		{
			return DataResult<ResponseAppointmentDetailsDto>.Failure("Appointment not found.");
		}

		var response = new ResponseAppointmentDetailsDto
		{
			Id = appointment.Id,
			Date = appointment.Date,
			
			DoctorId = appointment.DoctorId,
			DoctorFirstName = appointment.Doctor.FirstName,
			DoctorLastName = appointment.Doctor.LastName,
			DoctorEmail = appointment.Doctor.Email,
			DoctorPhone = appointment.Doctor.Phone,
			DoctorBranchName = appointment.Doctor.Branch.ToString(),

			PatientId = appointment.PatientId,
			PatientFirstName = appointment.Patient.FirstName,
			PatientLastName = appointment.Patient.LastName,
			PatientEmail = appointment.Patient.Email,
			PatientPhone = appointment.Patient.Phone,
		};

		return DataResult<ResponseAppointmentDetailsDto>.Success(response, "Appointment retrieved successfully.");
	}

	public IResult Update(UpdateAppointmentDto appointment)
	{
		var validationErrors = ValidateUpdateAppointmentDto(appointment);
		if (validationErrors.Any())
		{
			var errorMessage = string.Join(", ", validationErrors);
			return Result.FailureResult($"Validation failed: {errorMessage}");
		}

		var tempAppointment = _repository.Get(a => a.Id == appointment.Id);
		if (tempAppointment == null)
		{
			return Result.FailureResult("Appointment not found.");
		}

		tempAppointment.Date = appointment.Date;
		tempAppointment.DoctorId = appointment.DoctorId;
		tempAppointment.PatientId = appointment.PatientId;

		_repository.Update(tempAppointment);
		return Result.SuccessResult("Appointment updated successfully.");
	}

	private List<string> ValidateCreateAppointmentDto(CreateAppointmentDto dto)
	{
		var errors = new List<string>();
		DateTime today = DateTime.Now;
		var doctor = _doctorService.GetById(dto.DoctorId);

		if (dto.Date < today.AddDays(3))
			errors.Add("Appointment date must be at least 3 days in the future.");

		if (dto.Date < today)
			errors.Add("Appointment date must be in the future.");

		if (!doctor.Success)
			errors.Add("The selected doctor does not exist.");

		if(_repository.GetAll(a => a.DoctorId == doctor.Data.Id).Count >= 10)
			errors.Add("The selected doctor already has 10 patients.");

		return errors;
	}

	private List<string> ValidateUpdateAppointmentDto(UpdateAppointmentDto dto)
	{
		var errors = new List<string>();
		DateTime today = DateTime.Now;
		var doctor = _doctorService.GetById(dto.DoctorId);

		if (dto.Date < today.AddDays(3))
			errors.Add("Appointment date must be at least 3 days in the future.");

		if (dto.Date < today)
			errors.Add("Appointment date must be in the future.");

		if (!doctor.Success)
			errors.Add("The selected doctor does not exist.");

		if (_repository.GetAll(a => a.DoctorId == doctor.Data.Id).Count >= 10)
			errors.Add("The selected doctor already has 10 patients.");

		return errors;
	}
}

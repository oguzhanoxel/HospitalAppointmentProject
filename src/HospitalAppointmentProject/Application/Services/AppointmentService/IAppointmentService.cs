using Application.Services.AppointmentService.Dtos;
using Core.Application.Results.Abstracts;

namespace Application.Services.AppointmentService;

public interface IAppointmentService
{
	public IResult Create(CreateAppointmentDto appointment);
	public IResult Update(UpdateAppointmentDto appointment);
	public IResult Delete(DeleteAppointmentDto appointment);
	public IResult DeleteExpiredAppointments();
	public IDataResult<List<ResponseAppointmentDto>> GetAll();
	public IDataResult<List<ResponseAppointmentDetailsDto>> GetAllDetails();
	public IDataResult<List<ResponseAppointmentDetailsDto>> GetAllDetailsByDoctorId(int doctorId);
	public IDataResult<ResponseAppointmentDto> GetById(int id);
	public IDataResult<ResponseAppointmentDetailsDto> GetDetailsById(int id);
}

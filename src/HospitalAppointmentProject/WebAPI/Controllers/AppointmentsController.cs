using Application.Services.AppointmentService.Dtos;
using Application.Services.AppointmentService;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
	private readonly IAppointmentService _appointmentService;

	public AppointmentsController(IAppointmentService appointmentService)
	{
		_appointmentService = appointmentService;
	}

	[HttpGet]
	public IActionResult GetAll()
	{
		var result = _appointmentService.GetAll();
		if (result.Success)
			return Ok(result.Data);
		return BadRequest(result.Message);
	}

	[HttpGet("getalldetailsbydoctorid/{doctorId}")]
	public IActionResult GetAllDetailsByDoctorId(int doctorId)
	{
		var result = _appointmentService.GetAllDetailsByDoctorId(doctorId);
		if (result.Success)
			return Ok(result.Data);
		return BadRequest(result.Message);
	}

	[HttpGet("getalldetails")]
	public IActionResult GetAllDetails()
	{
		var result = _appointmentService.GetAllDetails();
		if (result.Success)
			return Ok(result.Data);
		return BadRequest(result.Message);
	}

	[HttpGet("{id}")]
	public IActionResult GetById(int id)
	{
		var result = _appointmentService.GetById(id);
		if (result.Success)
			return Ok(result.Data);
		return NotFound(result.Message);
	}

	[HttpGet("{id}/details")]
	public IActionResult GetDetailsById(int id)
	{
		var result = _appointmentService.GetDetailsById(id);
		if (result.Success)
			return Ok(result.Data);
		return NotFound(result.Message);
	}

	[HttpPost]
	public IActionResult Create([FromBody] CreateAppointmentDto appointmentDto)
	{
		var result = _appointmentService.Create(appointmentDto);
		if (result.Success)
			return Ok(result.Message);
		return BadRequest(result.Message);
	}

	[HttpPut]
	public IActionResult Update([FromBody] UpdateAppointmentDto appointmentDto)
	{
		var result = _appointmentService.Update(appointmentDto);
		if (result.Success)
			return Ok(result.Message);
		return NotFound(result.Message);
	}

	[HttpDelete]
	public IActionResult Delete(DeleteAppointmentDto appointmentDto)
	{
		var result = _appointmentService.Delete(appointmentDto);
		if (result.Success)
			return Ok(result.Message);
		return NotFound(result.Message);
	}

	[HttpDelete("expiredappointments")]
	public IActionResult DeleteExpiredAppointments()
	{
		var result = _appointmentService.DeleteExpiredAppointments();
		if (result.Success)
			return Ok(result.Message);
		return NotFound(result.Message);
	}
}

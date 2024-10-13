using Application.Services.PatientService.Dtos;
using Application.Services.PatientService;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
	private readonly IPatientService _patientService;

	public PatientsController(IPatientService patientService)
	{
		_patientService = patientService;
	}

	[HttpGet]
	public IActionResult GetAll()
	{
		var result = _patientService.GetAll();
		if (result.Success)
			return Ok(result.Data);
		return BadRequest(result.Message);
	}

	[HttpGet("{id}")]
	public IActionResult GetById(int id)
	{
		var result = _patientService.GetById(id);
		if (result.Success)
			return Ok(result.Data);
		return NotFound(result.Message);
	}

	[HttpPost]
	public IActionResult Create([FromBody] CreatePatientDto patientDto)
	{
		var result = _patientService.Create(patientDto);
		if (result.Success)
			return Ok(result.Message);
		return BadRequest(result.Message);
	}

	[HttpPut]
	public IActionResult Update([FromBody] UpdatePatientDto patientDto)
	{
		var result = _patientService.Update(patientDto);
		if (result.Success)
			return Ok(result.Message);
		return NotFound(result.Message);
	}

	[HttpDelete]
	public IActionResult Delete(DeletePatientDto patientDto)
	{
		var result = _patientService.Delete(patientDto);
		if (result.Success)
			return Ok(result.Message);
		return NotFound(result.Message);
	}
}

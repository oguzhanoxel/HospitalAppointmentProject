using Application.Services.DoctorService;
using Application.Services.DoctorService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
	private readonly IDoctorService _doctorService;

	public DoctorsController(IDoctorService doctorService)
	{
		_doctorService = doctorService;
	}

	[HttpGet]
	public IActionResult GetAll()
	{
		var result = _doctorService.GetAll();
		if (result.Success)
			return Ok(result.Data);
		return BadRequest(result.Message);
	}

	[HttpGet("{id}")]
	public IActionResult GetById(int id)
	{
		var result = _doctorService.GetById(id);
		if (result.Success)
			return Ok(result.Data);
		return NotFound(result.Message);
	}

	[HttpPost]
	public IActionResult Create([FromBody] CreateDoctorDto doctorDto)
	{
		var result = _doctorService.Create(doctorDto);
		if (result.Success)
			return Ok(result.Message);
		return BadRequest(result.Message);
	}

	[HttpPut]
	public IActionResult Update([FromBody] UpdateDoctorDto doctorDto)
	{
		var result = _doctorService.Update(doctorDto);
		if (result.Success)
			return Ok(result.Message);
		return NotFound(result.Message);
	}

	[HttpDelete]
	public IActionResult Delete([FromBody] DeleteDoctorDto doctorDto)
	{
		var result = _doctorService.Delete(doctorDto);
		if (result.Success)
			return Ok(result.Message);
		return NotFound(result.Message);
	}
}

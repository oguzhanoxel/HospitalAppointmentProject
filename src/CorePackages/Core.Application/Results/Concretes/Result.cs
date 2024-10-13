using Core.Application.Results.Abstracts;

namespace Core.Application.Results.Concretes;

public class Result : IResult
{
	public bool Success { get; }
	public string Message { get; }

	public Result(bool success, string message = "")
	{
		Success = success;
		Message = message;
	}

	public static Result SuccessResult(string message = "Operation succeeded.")
		=> new Result(true, message);

	public static Result FailureResult(string message = "Operation failed.")
		=> new Result(false, message);
}

using Core.Application.Results.Abstracts;

namespace Core.Application.Results.Concretes;

public class DataResult<T> : Result, IDataResult<T>
{
	public T Data { get; }

	public DataResult(T data, bool success, string message = "")
		: base(success, message)
	{
		Data = data;
	}

	public static DataResult<T> Success(T data, string message = "Operation succeeded.")
		=> new DataResult<T>(data, true, message);

	public static DataResult<T> Failure(string message = "Operation failed.")
		=> new DataResult<T>(default!, false, message);
}

namespace Core.Application.Results.Abstracts;

public interface IDataResult<T> : IResult
{
	T Data { get; }
}

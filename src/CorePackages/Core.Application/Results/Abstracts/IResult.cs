namespace Core.Application.Results.Abstracts;

public interface IResult
{
    bool Success { get; }
    string Message { get; }
}

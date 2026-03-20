using FluentResults;

namespace Application.Errors;

public class ApplicationError : Error
{
    private ApplicationError(string code, string title, string message, ErrorType type)
        : base(message)
    {
        Code = code;
        Title = title;
        Type = type;

        Metadata.Add("Code", code);
        Metadata.Add("Type", type);
    }

    public string Code { get; }
    public string? Title { get; }
    public ErrorType Type { get; }

    public static ApplicationError Validation(string code, string title, string message)
    {
        return new ApplicationError(code, title, message, ErrorType.Validation);
    }

    public static ApplicationError Forbidden(string code, string title, string message)
    {
        return new ApplicationError(code, title, message, ErrorType.Forbidden);
    }

    public static ApplicationError NotFound(string code, string title, string message)
    {
        return new ApplicationError(code, title, message, ErrorType.NotFound);
    }

    public static ApplicationError Conflict(string code, string title, string message)
    {
        return new ApplicationError(code, title, message, ErrorType.Conflict);
    }
}
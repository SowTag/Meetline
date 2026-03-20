using Application.Errors;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Web.Extensions;

public static class ResultExtensions
{
    public static IResult ToProblemDetails<T>(this Result<T> result)
    {
        if (result.IsSuccess) throw new InvalidOperationException("ToProblemDetails called on a successful result");

        var error = result.Errors[0];

        var details = new ProblemDetails
        {
            Title = "Unknown error",
            Detail = "An unmapped error occurred",
            Status = StatusCodes.Status500InternalServerError
        };

        if (error is not ApplicationError appError) return TypedResults.Problem(details);

        details.Title = appError.Title;
        details.Detail = appError.Message;
        details.Extensions["code"] = appError.Code;
        details.Status = appError.Type switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => throw new ArgumentOutOfRangeException(nameof(result),
                $"No mapping for {appError.Type} to a HTTP status code")
        };

        return TypedResults.Problem(details);
    }
}
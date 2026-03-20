namespace Application.Errors;

public enum ErrorType
{
    /// <summary>
    ///     A validation failed, the failure is caused due to a wrong user input.
    /// </summary>
    Validation,

    /// <summary>
    ///     The user is forbidden from executing the action or query.
    /// </summary>
    Forbidden,

    /// <summary>
    ///     The resource was not found.
    /// </summary>
    NotFound,

    /// <summary>
    ///     The action or query produces a conflict.
    /// </summary>
    Conflict
}
using Meetline.Modules.SharedKernel.Application.Errors;

namespace Application.Errors.ErrorTypes;

public abstract class ConflictError(string code, string title, string message) : ApplicationError(code, title, message);
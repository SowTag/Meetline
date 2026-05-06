using Meetline.Modules.SharedKernel.Application.Errors;

namespace Application.Errors.ErrorTypes;

public abstract class InternalError(string code, string title, string message) : ApplicationError(code, title, message);
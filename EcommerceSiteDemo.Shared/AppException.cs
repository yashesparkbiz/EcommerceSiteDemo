using EcommerceSiteDemo.Shared;
using EcommerceSiteDemo.Shared.Enums;
using FluentValidation.Results;

namespace SadiantApi.Shared;

public class AppException : Exception
{
    public AppException(string message, AppStatusCodeError statusCodeError)
        : base(message)
    {
        ErrorResponse = new BaseResponseOut(message);
        StatusCodeError = statusCodeError;
    }

    public AppException(string message, AppStatusCodeError statusCodeError, List<string> errors)
        : base(message)
    {
        ErrorResponse = new BaseResponseOut(message, errors);
        StatusCodeError = statusCodeError;
    }

    public AppException(string message, AppStatusCodeError statusCodeError, Exception innerException)
        : base(message, innerException)
    {
        ErrorResponse = new BaseResponseOut(message);
        StatusCodeError = statusCodeError;
    }

    public BaseResponseOut ErrorResponse { get; set; }
    public AppStatusCodeError StatusCodeError { get; set; }
}

public class AppValidationException : AppException
{
    const string message = "One or more validation errors occurred.";
    public AppValidationException(List<ValidationFailure> validationFailures)
        : base(message, AppStatusCodeError.BadRequest400)
    {
        ValidationFailures = validationFailures;
    }

    public AppValidationException(List<ValidationFailure> validationFailures, Exception innerException)
        : base(message, AppStatusCodeError.BadRequest400, innerException)
    {
        ValidationFailures = validationFailures;
    }

    public List<ValidationFailure> ValidationFailures { get; set; }
}

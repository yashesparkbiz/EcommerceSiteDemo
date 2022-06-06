global using CT = System.Threading.CancellationToken;
using EcommerceSiteDemo.Shared;
using EcommerceSiteDemo.Shared.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
namespace EcommerceSiteDemo.Controllers.Shared;

[ApiController]
public class AppApiControllerBase : ControllerBase
{
    public readonly ILogger<AppApiControllerBase> _logger;
    public readonly IMediator _mediator;

    public AppApiControllerBase(ILogger<AppApiControllerBase> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    protected async Task<IActionResult> AppActionResultAsync(IRequest<AppHandlerResponse> request, CancellationToken cancellationToken)
    {
        var handlerResponse = await _mediator.Send(request, cancellationToken);
        return handlerResponse.HasResponse ? Ok(handlerResponse.Response) : ExceptionToActionResult(handlerResponse.Failure ?? new Exception("Unexpected Error"));
    }

    internal IActionResult ExceptionToActionResult(Exception ex)
    {
        return ex switch
        {
            AppValidationException appValEx => HandleAppValException(appValEx),
            AppException appEx => HandleAppException(appEx),
            _ => HandleAnyException(ex)
        };

        IActionResult HandleAppValException(AppValidationException appValEx)
        {
            var modelStateDictionary = new ModelStateDictionary();
            appValEx.ValidationFailures.ForEach(e =>
                modelStateDictionary.AddModelError(e.PropertyName.Replace("In.", null), e.ErrorMessage));
            return ValidationProblem(modelStateDictionary);
        }

        IActionResult HandleAppException(AppException lfex)
        {
            var statusCode = (int)lfex.StatusCodeError;
            var detail = ReasonPhrases.GetReasonPhrase(statusCode);
            return AppExceptionToActionResult(lfex);
        }

        IActionResult HandleAnyException(Exception ex)
        {
            var statusCode = (int)GetStatusCodeForException(ex);
            var message = string.IsNullOrWhiteSpace(ex.Message) ? "Unexpected Error" : ex.Message;
            var detail = CleanMessage(message) ?? ReasonPhrases.GetReasonPhrase(statusCode);
            return Problem(detail, HttpContext.Request.Path, statusCode);
        }

        ObjectResult Forbidden(object error) => StatusCode(StatusCodes.Status403Forbidden, error);

        ObjectResult InternalServerError(object error) => StatusCode(StatusCodes.Status500InternalServerError, error);

        static string? CleanMessage(string? message) => message?.Replace("See the inner exception for details.", "").Trim();

        static AppStatusCodeError GetStatusCodeForException(Exception exception) =>
            exception switch
            {
                FormatException _ => AppStatusCodeError.BadRequest400,
                ArgumentException _ => AppStatusCodeError.BadRequest400,
                InvalidOperationException _ => AppStatusCodeError.Conflict409,
                _ => AppStatusCodeError.InternalServerError500
            };

        IActionResult AppExceptionToActionResult(AppException ex)
        {
            Func<BaseResponseOut, ObjectResult> result = ex.StatusCodeError switch
            {
                AppStatusCodeError.BadRequest400 => BadRequest,
                AppStatusCodeError.Forbidden403 => Forbidden,
                AppStatusCodeError.NotFound404 => NotFound,
                AppStatusCodeError.Conflict409 => Conflict,
                AppStatusCodeError.InternalServerError500 => InternalServerError,
                _ => InternalServerError
            };

            return result(ex.ErrorResponse);
        }
    }
}

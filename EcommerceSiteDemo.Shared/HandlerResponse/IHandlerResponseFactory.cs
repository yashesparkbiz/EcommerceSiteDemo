using EcommerceSiteDemo.Shared.Enums;
using SadiantApi.Shared;

namespace EcommerceSiteDemo.Shared;

public interface IHandlerResponseFactory
{
    AppHandlerResponse Success(BaseResponseOut response);

    AppHandlerResponse Error(AppException ex);
    AppHandlerResponse Error(string message, AppStatusCodeError statusCodeError);
    AppHandlerResponse Error(string message, AppStatusCodeError statusCodeError, List<string> errors);
    AppHandlerResponse Error(string message, AppStatusCodeError statusCodeError, Exception innerException);

    AppHandlerResponse ErrorAndCommitPartialChanges(AppException ex);
    AppHandlerResponse ErrorAndCommitPartialChanges(string message, AppStatusCodeError statusCodeError);
    AppHandlerResponse ErrorAndCommitPartialChanges(string message, AppStatusCodeError statusCodeError, List<string> errors);
    AppHandlerResponse ErrorAndCommitPartialChanges(string message, AppStatusCodeError statusCodeError, Exception innerException);
}

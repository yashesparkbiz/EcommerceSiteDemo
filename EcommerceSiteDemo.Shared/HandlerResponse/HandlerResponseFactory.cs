using EcommerceSiteDemo.Shared;
using EcommerceSiteDemo.Shared.Enums;
using SadiantApi.Shared;

namespace EcommerceSiteDemo.Shared;

public class HandlerResponseFactory : IHandlerResponseFactory
{
    public AppHandlerResponse Success(BaseResponseOut response) =>
        new(response);


    public AppHandlerResponse Error(AppException ex) =>
        new(ex, rollbackOnFailure: true);
    public AppHandlerResponse Error(string message, AppStatusCodeError statusCodeError) =>
        new(new AppException(message, statusCodeError), rollbackOnFailure: true);
    public AppHandlerResponse Error(string message, AppStatusCodeError statusCodeError, List<string> errors) =>
        new(new AppException(message, statusCodeError, errors), rollbackOnFailure: true);
    public AppHandlerResponse Error(string message, AppStatusCodeError statusCodeError, Exception innerException) =>
        new(new AppException(message, statusCodeError, innerException), rollbackOnFailure: true);


    public AppHandlerResponse ErrorAndCommitPartialChanges(AppException ex) =>
        new(ex, rollbackOnFailure: false);
    public AppHandlerResponse ErrorAndCommitPartialChanges(string message, AppStatusCodeError statusCodeError) =>
        new(new AppException(message, statusCodeError), rollbackOnFailure: false);
    public AppHandlerResponse ErrorAndCommitPartialChanges(string message, AppStatusCodeError statusCodeError, List<string> errors) =>
        new(new AppException(message, statusCodeError, errors), rollbackOnFailure: false);
    public AppHandlerResponse ErrorAndCommitPartialChanges(string message, AppStatusCodeError statusCodeError, Exception innerException) =>
        new(new AppException(message, statusCodeError, innerException), rollbackOnFailure: false);
}

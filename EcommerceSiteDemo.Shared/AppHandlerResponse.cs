using EcommerceSiteDemo.Shared;

namespace EcommerceSiteDemo.Shared;

public class AppHandlerResponse
{
    private BaseResponseOut? _response;
    private AppException? _failure;
    private bool? _rollbackOnFailure;

    public AppHandlerResponse(BaseResponseOut response)
    {
        _response = response;
        _failure = null;
        _rollbackOnFailure = null;
    }

    public AppHandlerResponse(AppException ex, bool rollbackOnFailure = true)
    {
        _response = null;
        _failure = ex;
        _rollbackOnFailure = rollbackOnFailure;
    }

    public bool HasResponse { get => _response is not null; }
    public bool HasFailure { get => _failure is not null; }
    public bool HasFailureAndRollbackOnFailure { get => _failure is not null && _rollbackOnFailure.GetValueOrDefault(true); }

    public BaseResponseOut? Response { get => _response; }
    public AppException? Failure { get => _failure; }

    public void SetResponse(BaseResponseOut response)
    {
        _response = response;
        _failure = null;
        _rollbackOnFailure = null;
    }

    public void SetFailure(AppException ex, bool rollbackOnFailure = true)
    {
        _response = null;
        _failure = ex;
        _rollbackOnFailure = rollbackOnFailure;
    }
}

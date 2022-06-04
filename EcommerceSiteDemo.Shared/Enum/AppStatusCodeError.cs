using System.Net;

namespace EcommerceSiteDemo.Shared.Enums;
public enum AppStatusCodeError
{
    /**
     * Do not add Unauthorized401 to this enum.
     * 401 should only be returned by the framework when the JWT token is not valid,
     * otherwise returning a custom 401 might cause issues with the RefreshTokenInterceptor in the front-end.
     * Instead use Forbidden403 if needed.
     */
    BadRequest400 = HttpStatusCode.BadRequest,
    Forbidden403 = HttpStatusCode.Forbidden,
    NotFound404 = HttpStatusCode.NotFound,
    Conflict409 = HttpStatusCode.Conflict,
    InternalServerError500 = HttpStatusCode.InternalServerError
}

public static class AppStatusCodeErrorExtensions
{
    public static AppStatusCodeError SafeCast(this AppStatusCodeError @this)
    {
        return Enum.IsDefined(@this) ? @this : AppStatusCodeError.InternalServerError500;
    }
}

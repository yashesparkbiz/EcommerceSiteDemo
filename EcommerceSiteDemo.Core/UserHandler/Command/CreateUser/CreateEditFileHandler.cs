using EcommerceSiteDemo.Data.Data;
using EcommerceSiteDemo.Shared;
using MediatR;
using EcommerceSiteDemo.Core.Commands;

namespace EcommerceSiteDemo.Core.HandleFiles.Commands;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, AppHandlerResponse>
{
    private readonly IHandlerResponseFactory _response;
    private readonly EcommerceSiteContext _db;

    public CreateUserHandler(
        IHandlerResponseFactory response,
        EcommerceSiteContext db)
    {
        _response = response;
        _db = db;
    }

    public async Task<AppHandlerResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {

        return _response.Success(new CreateUserOut("File uploaded successfuly."));

    }
}
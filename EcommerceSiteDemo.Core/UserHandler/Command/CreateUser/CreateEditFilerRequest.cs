using EcommerceSiteDemo.Shared;
using MediatR;

namespace EcommerceSiteDemo.Core.Commands;

public class CreateUserRequest : IRequest<AppHandlerResponse>
{
    public CreateUserRequest()
    {
    }
}

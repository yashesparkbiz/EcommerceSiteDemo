using EcommerceSiteDemo.Shared;
using MediatR;

namespace SadiantApi.Core.Commands;

public class CreateUserRequest : IRequest<AppHandlerResponse>
{
    public CreateUserRequest()
    {
    }
}

using EcommerceSiteDemo.Controllers.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EcommerceSiteDemo.Core.Commands;

namespace EcommerceSiteDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : AppApiControllerBase
    {
        public UserController(ILogger<UserController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        //[AuthorizeApi(Role.Administrators, Role.ClientAdministrator)]
        [HttpPost("")]
        public async Task<IActionResult> AddUser(CT ct) => await AppActionResultAsync(new CreateUserRequest(), ct);
    }
}
using FluentValidation;
using EcommerceSiteDemo.Core.Commands;

namespace EcommerceSiteDemo.Core.HandleFiles.Commands;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {

    }
}
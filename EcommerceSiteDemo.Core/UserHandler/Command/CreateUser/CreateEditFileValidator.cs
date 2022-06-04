using FluentValidation;
using SadiantApi.Core.Commands;

namespace SadiantApi.Core.HandleFiles.Commands;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {

    }
}
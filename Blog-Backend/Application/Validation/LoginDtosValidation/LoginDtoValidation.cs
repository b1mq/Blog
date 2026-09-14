using System;
using System.Collections.Generic;
using System.Text;
using Application.Dtos.User.LoginDtos;
using FluentValidation;

namespace Application.Validation.LoginDtosValidation
{
    public class LoginValidation : AbstractValidator<LoginDto>
    {
        public LoginValidation()
        {
            RuleFor(x => x.name)
                .NotEmpty()
                .WithMessage("Name cannot be empty.")
                .MinimumLength(3)
                .WithMessage("Name is too short.")
                .MaximumLength(100)
                .WithMessage("Name is too long.");

            RuleFor(x => x.password)
                .NotEmpty()
                .WithMessage("Password cannot be empty.")
                .MinimumLength(6)
                .WithMessage("Password is too short.")
                .MaximumLength(100)
                .WithMessage("Password is too long.");
        }
    }
}

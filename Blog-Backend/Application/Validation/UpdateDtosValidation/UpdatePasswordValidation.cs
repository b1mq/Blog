using System;
using System.Collections.Generic;
using System.Text;
using Application.Dtos.UserDtos.UpdateDtos;
using FluentValidation;

namespace Application.Validation.UpdateDtosValidation
{
    public class UpdatePasswordValidation : AbstractValidator<UpdatePasswordDto>
    {
        public UpdatePasswordValidation()
        {
            RuleFor(x => x.oldpassword)
                .NotEmpty()
                .WithMessage("Old password cannot be empty.");

            RuleFor(x => x.newpassword)
                .NotEmpty()
                .WithMessage("New password cannot be empty.")
                .MinimumLength(6)
                .WithMessage("New password is too short.")
                .MaximumLength(100)
                .WithMessage("New password is too long.")
                .NotEqual(x => x.oldpassword)
                .WithMessage("New password must be different from the old password.");
        }
    }
}

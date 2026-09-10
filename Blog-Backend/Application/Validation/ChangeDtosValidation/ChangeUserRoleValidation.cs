using System;
using System.Collections.Generic;
using System.Text;
using Application.Dtos.ChangeDtos;
using FluentValidation;

namespace Application.Validation.ChangeDtosValidation
{
    public sealed class ChangeUserRoleValidation:AbstractValidator<ChangeUserRoleDto>
    {
        public ChangeUserRoleValidation()
        {
            RuleFor(x => x.oldrole)
                .IsInEnum()
                .WithMessage("Invalid old role specified.");

            RuleFor(x => x.newrole)
                .IsInEnum()
                .WithMessage("Invalid new role specified.")
                .NotEqual(x => x.oldrole)
                .WithMessage("New role must be different from the old role you idiot.");
        }
    }
}

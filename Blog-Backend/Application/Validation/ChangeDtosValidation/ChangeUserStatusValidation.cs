using System;
using System.Collections.Generic;
using System.Text;
using Application.Dtos.ChangeDtos;
using FluentValidation;

namespace Application.Validation.ChangeDtosValidation
{
    public class ChangeUserStatusValidation:AbstractValidator<ChangeUserStatusDto>
    {
        public ChangeUserStatusValidation()
        {
            RuleFor(x => x.oldstatus)
                .IsInEnum()
                .WithMessage("Invalid old role specified.");

            RuleFor(x => x.newstatus)
                .IsInEnum()
                .WithMessage("Invalid new role specified.")
                .NotEqual(x => x.newstatus)
                .WithMessage("New role must be different from the old role.");
        }
    }
}

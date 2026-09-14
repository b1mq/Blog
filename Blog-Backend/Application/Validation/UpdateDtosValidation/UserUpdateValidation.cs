using System;
using System.Collections.Generic;
using System.Text;
using Application.Dtos.User.UpdateDtos;
using FluentValidation;

namespace Application.Validation.UpdateDtosValidation
{
    public class UserUpdateValidation : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateValidation()
        {
            RuleFor(x => x.name)
                .NotEmpty()
                .WithMessage("Name cannot be empty.")
                .MinimumLength(3)
                .WithMessage("Name is too short.")
                .MaximumLength(100)
                .WithMessage("Name is too long.");

            RuleFor(x => x.email)
                .NotEmpty()
                .WithMessage("Email cannot be empty.")
                .EmailAddress()
                .WithMessage("Incorrect email address.")
                .MaximumLength(255)
                .WithMessage("Email is too long.");

            RuleFor(x => x.country)
                .NotEmpty()
                .WithMessage("Country cannot be empty.")
                .MinimumLength(2)
                .WithMessage("Country name is too short.")
                .MaximumLength(25)
                .WithMessage("Country name is too long.");

            RuleFor(x => x.avatarurl)
                .MaximumLength(500).WithMessage("Avatar URL length cannot exceed 500 characters.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                             && (uriResult.Scheme == Uri.UriSchemeHttps || uriResult.Scheme == Uri.UriSchemeHttp))
                .WithMessage("Avatar URL must be a valid HTTP or HTTPS web address.")
                .Must(url => {
                    if (!Uri.TryCreate(url, UriKind.Absolute, out var uri)) return false;
                    var extension = Path.GetExtension(uri.AbsolutePath);
                    return extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                           extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                           extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
                           extension.Equals(".webp", StringComparison.OrdinalIgnoreCase);
                })
                .WithMessage("Avatar URL must point to a supported image format (.jpg, .jpeg, .png, .webp).")
                .When(x => !string.IsNullOrWhiteSpace(x.avatarurl));
        }
    }
}

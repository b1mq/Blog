using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Application.Dtos.ViewDtos
{
    public sealed record UserViewDto(string name, string email, string country, string avatarurl, Roles role, Status status);
}

using System;
using System.Collections.Generic;
using System.Text;
using Application.Dtos.ViewDtos;

namespace Application.Dtos.LoginDtos
{
    public sealed record AuthResponseDto(UserViewDto User, string Token);
}

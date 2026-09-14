using System;
using System.Collections.Generic;
using System.Text;
using Application.DtosDtos.User.ViewDtos;

namespace Application.Dtos.UserDtos.LoginDtos
{
    public sealed record AuthResponseDto(UserViewDto User, string Token);
}

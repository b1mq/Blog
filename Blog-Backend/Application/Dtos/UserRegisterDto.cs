using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public sealed record UserRegisterDto(string name, string email, string password, string country, string avatarurl);
}

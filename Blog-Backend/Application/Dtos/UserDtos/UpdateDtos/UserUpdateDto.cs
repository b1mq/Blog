using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.UserDtos.UpdateDtos
{
    public sealed record UserUpdateDto(string name,string email,string country,string avatarurl);
}

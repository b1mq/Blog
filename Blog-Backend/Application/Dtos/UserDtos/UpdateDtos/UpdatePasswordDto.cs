using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.UserDtos.UpdateDtos
{
    public sealed record UpdatePasswordDto(string oldpassword, string newpassword);
}

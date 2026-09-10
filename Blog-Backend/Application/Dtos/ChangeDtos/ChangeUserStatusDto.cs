using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;
namespace Application.Dtos.ChangeDtos
{
    public sealed record ChangeUserStatusDto(Status oldstatus, Status newstatus);
}

using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;
using Domain.Entities;
namespace Application.Dtos.ViewDtos
{
    public sealed record UserViewDto(Guid Id,string name, string email, string country, string avatarurl, Roles role, Status status) 
    {
        public static UserViewDto ConvertFromEntityToDtoUser(User user)
        {
            return new UserViewDto(user.Id,user.Name, user.Email, user.Country, user.ThumbnailUrl, user.Role, user.Status);
        }
    
    };
}

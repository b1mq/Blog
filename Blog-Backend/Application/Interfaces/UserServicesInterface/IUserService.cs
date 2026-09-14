using System;
using System.Collections.Generic;
using System.Text;
using Application.Dtos.ChangeDtos;
using Application.Dtos.UserDtos.LoginDtos;
using Application.Dtos.UserDtos.RegisterDtos;
using Application.Dtos.UserDtos.UpdateDtos;
using Application.Dtos.UserDtos.ViewDtos;
using Domain.Entities;
namespace Application.Interfaces.UserServicesInterface
{
    public interface IUserService
    {
        Task<Result> RegisterUser(UserRegisterDto dtoUser);
        Task<Result> UpdateUser(LoginDto dtoUser,UserUpdateDto update);
        Task<ResultGeneric<AuthResponseDto>> LoginUser(LoginDto dtoUser);
        Task<Result> DeleteUser(LoginDto dtoUser);
        Task<ResultGeneric<UserViewDto>> GetUserById(Guid id);
        Task<Result> UpdatePassword(Guid Id, UpdatePasswordDto dto);
    
       
    }
}

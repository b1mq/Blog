using System;
using System.Collections.Generic;
using System.Text;
using Application.Dtos.LoginDtos;
using Application.Dtos.RegisterDto;
using Application.Dtos.UpdateDtos;
using Application.Dtos.ViewDtos;
using Application.Interfaces.AuthInterfaces;
using Application.Interfaces.HashServiceInterface;
using Application.Interfaces.UserServicesInterface;
using Application.Services.HashService;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.UserService
{
    public class UserService:IUserService
    {
        private readonly IUserWriteRepository _writeRepo;
        private readonly IUserReadRepository _readRepo;
        private readonly IHashService _hasher;
        private readonly IJwtProvider _jwtProvider;
        public UserService(IUserReadRepository readRepo, IJwtProvider jwtProvider, IUserWriteRepository writeRepo,IHashService myhasher)
        {
            _writeRepo = writeRepo;
            _readRepo = readRepo;
            _jwtProvider = jwtProvider;
            _hasher = myhasher;
        }
        public async Task<Result> RegisterUser(UserRegisterDto dtoUser)
        {
            var existingUser = await _readRepo.GetUserByEmailAsync(dtoUser.email);
            if(existingUser != null)
            {
                return Result.Failure("User with this email already exist.Try to login");
            }
            var hashedPassword = _hasher.HashPassword(dtoUser.password);
            var newUser = User.Create(dtoUser.name, dtoUser.email, hashedPassword, dtoUser.country, dtoUser.avatarurl);
            if(!newUser.isSucces || newUser.value == null)
            {
                return Result.Failure(newUser.Error);
            }
            await _writeRepo.AddUserAsync(newUser.value);
            await _writeRepo.SaveChangesAsync();
            return Result.Succes(); 

        }
        public async Task<Result> UpdateUser(LoginDto dtoUser, UserUpdateDto update)
        {

            var user = await _readRepo.GetByNameAsync(dtoUser.name);
            if (user == null)
            {
                return Result.Failure("Invalid credentials.");
            }
            bool isPasswordValid = _hasher.VerifyPassword(user.PasswordHash, dtoUser.password);
            if (!isPasswordValid)
            {
                return Result.Failure("Invalid credentials.");
            }
            if(user.Email != update.email)
            {
                var usersEmails = await _readRepo.GetUserByEmailAsync(update.email);
                if (usersEmails != null)
                {
                    return Result.Failure($"User with email {update.email} is arleady exists");
                }
            }
            
            var nameResult = user.SetName(update.name);
            if (!nameResult.isSucces) return Result.Failure(nameResult.Error);

            var emailResult = user.SetEmail(update.email);
            if (!emailResult.isSucces) return Result.Failure(emailResult.Error);

            var countryResult = user.SetCountry(update.country);
            if (!countryResult.isSucces) return Result.Failure(countryResult.Error);

            var thumbnailResult = user.SetThumbnail(update.avatarurl);
            if (!thumbnailResult.isSucces) return Result.Failure(thumbnailResult.Error);

            
            await _writeRepo.EditUserAsync(user);
            await _writeRepo.SaveChangesAsync();

            return Result.Succes();
        }
        public async Task<ResultGeneric<AuthResponseDto>> LoginUser(LoginDto dtoUser)
        {
            var user = await _readRepo.GetByNameAsync(dtoUser.name);
            if (user == null)
            {
                return ResultGeneric<AuthResponseDto>.Failure("Invalid credentials.");
            }

            
            bool isPasswordValid = _hasher.VerifyPassword(user.PasswordHash, dtoUser.password);
            if (!isPasswordValid)
            {
                return ResultGeneric<AuthResponseDto>.Failure("Invalid credentials.");
            }
            var result = UserViewDto.ConvertFromEntityToDtoUser(user);
            var token = _jwtProvider.GenerateToken(user);
            var response = new AuthResponseDto(result, token);
            return ResultGeneric<AuthResponseDto>.Succes(response);
        }
        public async Task<Result> DeleteUser(LoginDto dtoUser)
        {
            var user = await _readRepo.GetByNameAsync(dtoUser.name);
            if(user == null)
            {
                return Result.Failure("Try again");
            }
            bool isPasswordValid = _hasher.VerifyPassword(user.PasswordHash, dtoUser.password);
            if(!isPasswordValid)
            {
                return Result.Failure("Try again idk");
            }
            await _writeRepo.RemoveUserAsync(user);
            await _writeRepo.SaveChangesAsync();
            return Result.Succes();
        }
        public async Task<ResultGeneric<UserViewDto>> GetUserById(Guid id)
        {
            var user = await _readRepo.GetUserAsync(id);
            if(user == null )
            {
                return ResultGeneric<UserViewDto>.Failure($"User with id: {id} not found");
            } 
            var viewdto = UserViewDto.ConvertFromEntityToDtoUser(user);
            return ResultGeneric<UserViewDto>.Succes(viewdto);
        }

        public async Task<Result> UpdatePassword(Guid id, UpdatePasswordDto dto)
        {
            var user = await _readRepo.GetUserAsync(id);
            if(user == null )
            {
                return Result.Failure("User Not Found");
            }
            bool isPasswordValid = _hasher.VerifyPassword(user.PasswordHash,dto.oldpassword);
            if(!isPasswordValid)
            {
                return Result.Failure("Incorrect old password");
            }
            var newpassHash = _hasher.HashPassword(dto.newpassword);
            var result = user.SetPasswordHash(newpassHash);
            if (!result.isSucces)
            {
                return result;
            }
            await _writeRepo.EditUserAsync(user);
            await _writeRepo.SaveChangesAsync();
           
            return Result.Succes();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Domain.Enums;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public string Country { get; private set; } = string.Empty;
        public string ThumbnailUrl { get; private set; } = string.Empty;
        public Roles Role { get;  private set; } = Roles.User;
        public Status Status { get; private set; } = Status.Pending;
        public DateTime CreatedAt { get; private set; }
        public DateTime LastActivity { get; private set; }
        protected User() { }
        protected User(Guid id,string name,string email,string passwordHash,string country,string thumbnailUrl)
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Country = country;
            ThumbnailUrl = thumbnailUrl;
            CreatedAt = DateTime.UtcNow;
            LastActivity = DateTime.UtcNow;
        }
        public static  ResultGeneric<User>Create(string Name,string Email,string PasswordHash,string Country,string ThumbnailUrl)
        {
            if (string.IsNullOrWhiteSpace(Name))
                return ResultGeneric<User>.Failure("Are you drunk? Name can not be empty");

            if (string.IsNullOrWhiteSpace(Email))
                return ResultGeneric<User>.Failure("Email cannot be empty");
            if (string.IsNullOrWhiteSpace(Country))
                return ResultGeneric<User>.Failure("Country can not be empty you bastard");
            var user = new User(Guid.NewGuid(),Name,Email,PasswordHash,Country,ThumbnailUrl);
            return ResultGeneric<User>.Succes(user);

        }
        private void UpdateActivity() => LastActivity = DateTime.UtcNow;

        private Result IsValid(string value)
        {
            
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure("Value can not be empty");
            }
            return Result.Succes();
        }
        public Result SetName(string value)
        {
            var validationResult = IsValid(value);
            if(!validationResult.isSucces )
            {
                return validationResult;
            }
            Name = value;
            UpdateActivity();
            return Result.Succes();

        }
        public Result SetEmail(string value)
        {
            var validationResult = IsValid(value);
            if (!validationResult.isSucces)
            {
                return validationResult;
            }
            Email = value;
            UpdateActivity();
            return Result.Succes();

        }
        public Result SetCountry(string value)
        {
            var validationResult = IsValid(value);
            if (!validationResult.isSucces)
            {
                return validationResult;
            }
            Country = value;
            UpdateActivity();
            return Result.Succes();

        }
        public Result SetThumbnail(string value)
        {
            var validationResult = IsValid(value);
            if (!validationResult.isSucces)
            {
                return validationResult;
            }
            ThumbnailUrl = value;
            UpdateActivity();
            return Result.Succes();

        }

    }
}

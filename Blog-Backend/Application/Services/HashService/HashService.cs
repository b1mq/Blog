using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Application.Interfaces.HashServiceInterface;

namespace Application.Services.HashService
{
    public class HashService:IHashService
    {
         private readonly PasswordHasher<object> _passwordHasher = new();
        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null!,password);
        }
        public bool VerifyPassword(string passwordHash,string password)
        {
            var res = _passwordHasher.VerifyHashedPassword(null!,passwordHash,password);
            return res == PasswordVerificationResult.Success;
        }
    }
}

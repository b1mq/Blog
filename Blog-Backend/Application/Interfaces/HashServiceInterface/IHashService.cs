using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.HashServiceInterface
{
    public interface IHashService
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashpassword,string providedpassword); // хешированный пароль и пароль который предпологается
    }
}

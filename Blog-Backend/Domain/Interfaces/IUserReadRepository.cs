using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Enums;
namespace Domain.Interfaces
{
    public interface IUserReadRepository
    {
        Task<User?> GetUserAsync(Guid id);
        Task<IReadOnlyList<User>> GetUsersAsync(string name);
        Task<User?> GetUserByEmailAsync(string email);
        Task<IReadOnlyList<User>> GetCreatedUsersByTimeAsync(DateTime createdAt);
        Task<IReadOnlyList<User>> GetUsersByCountryAsync(string country);
        Task<IReadOnlyList<User>> GetUsersByRoleAsync(Roles role);


    }
}

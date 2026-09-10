using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserWriteRepository
    {
        Task<User?> GetUserAsync(Guid id);
        Task AddUserAsync(User user);
        Task EditUserAsync(User user);
        Task RemoveUserAsync(User user);
        Task RemoveUserByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}

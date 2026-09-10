using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositores.Users
{
    public class UserWriteRepository:IUserWriteRepository
    {
        private readonly BlogDbContext _db;
        public UserWriteRepository(BlogDbContext db)
        {
            _db = db;
        }

        public async Task<User?> GetUserAsync(Guid id)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddUserAsync(User user)
        {
            await _db.Users.AddAsync(user);
        }
        public  Task EditUserAsync(User user)
        {
            _db.Users.Update(user);
            return Task.CompletedTask;
        }
        public  Task RemoveUserAsync(User user)
        {
            _db.Users.Remove(user);
            return Task.CompletedTask;
        }
        public  async Task RemoveUserByIdAsync(Guid id)
        {
            await _db.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
    }
}

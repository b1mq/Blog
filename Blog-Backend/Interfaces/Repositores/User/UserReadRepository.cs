using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.DbContexts;
namespace Infrastructure.Repositores.Users
{
    public class UserReadRepository:IUserReadRepository
    {
        private readonly BlogDbContext _db;
        public UserReadRepository(BlogDbContext db)
        {
            _db = db;
        }
        public async Task<User?> GetUserAsync(Guid id)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IReadOnlyList<User>> GetUsersAsync(string name)
        {
            return await _db.Users.Where(x=> x.Name == name).ToListAsync();
        }
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
            
        }
        public async Task<IReadOnlyList<User>> GetCreatedUsersByTimeAsync(DateTime createdAt)
        {
            return await _db.Users.Where(x => x.CreatedAt == createdAt).ToListAsync();
        }
        public async Task<IReadOnlyList<User>> GetUsersByCountryAsync(string country)
        {
            return await _db.Users.Where(x => x.Country == country)  .ToListAsync();
        }
        public async Task<IReadOnlyList<User>> GetUsersByRoleAsync(Roles role)
        {
            return await _db.Users.Where(x => x.Role == role) .ToListAsync();
        }

    }
}

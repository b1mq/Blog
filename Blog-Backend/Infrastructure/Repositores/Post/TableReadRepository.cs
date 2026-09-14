using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.DbContexts;
namespace Infrastructure.Repositores.Posts
{
    public class TableReadRepository:ITableReadRepository
    {
        private readonly BlogDbContext _db;
        public TableReadRepository(BlogDbContext db)
        {
            _db = db;
        }
        public async Task<Post?> GetPostAsync(Guid id)
        {
            return await _db.Posts.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IReadOnlyList<Post>> GetPostsByTitleAsync(string title)
        {
            return await _db.Posts.Where(p => p.Title == title).ToListAsync();
        }
        public async Task<Post?> GetPostByUserIdAsync(Guid userId)
        {
            return await _db.Posts.FirstOrDefaultAsync(p =>p.UserId == userId);

        }
        public async Task<IReadOnlyList<Post>> GetAllPostByUserIdAsync(Guid userId)
        {
            return await _db.Posts.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<IReadOnlyList<Post>> GetCreatedPostsByTimeAsync(DateTime createdAt)
        {
            return await _db.Posts.Where(p => p.CreatedAt == createdAt).ToListAsync();
        }
        public async Task<Post?> GetPostByTitleAsync(string title)
        {
            return await _db.Posts.FirstOrDefaultAsync(p => p.Title == title);
        }
    }
}

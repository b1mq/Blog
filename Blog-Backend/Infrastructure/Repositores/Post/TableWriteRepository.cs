using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using Infrastructure.Persistence.DbContexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositores.Posts
{
    public  class TableWriteRepository:ITableWriteRepository
    {
        private readonly BlogDbContext _db;
        public TableWriteRepository(BlogDbContext db) 
        {
            _db = db;
        }
        public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
        public async Task AddNewPostAsync(Post post)
        {
            await _db.Posts.AddAsync(post);
          
        }
        public  Task RemovePostAsync(Post post)
        {
             _db.Posts.Remove(post);
            return Task.CompletedTask;
           
        }
        public  async Task RemovePostByIdAsync(Guid id)
        {
           var postToDelete = await _db.Posts.FirstOrDefaultAsync(p => p.Id == id);
            if(postToDelete == null)
            {
                return;
            }
            _db.Posts.Remove(postToDelete);
         
        }
        public  Task EditPostAsync(Post post)
        {
            _db.Posts.Update(post);
            return Task.CompletedTask;
        }

    }
}

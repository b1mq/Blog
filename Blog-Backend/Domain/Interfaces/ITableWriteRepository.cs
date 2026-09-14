using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITableWriteRepository
    {
        
        Task AddNewPostAsync(Post post);
        Task RemovePostAsync(Post post);
        Task RemovePostByIdAsync(Guid id);
        Task EditPostAsync(Post post);
        Task SaveChangesAsync();
    }
}

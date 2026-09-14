using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Interfaces
{
    public interface ITableReadRepository
    {
        Task<Post?> GetPostAsync(Guid id);
        Task<IReadOnlyList<Post>> GetPostsByTitleAsync(string title);
        Task<Post?> GetPostByUserIdAsync(Guid userId);
        Task<IReadOnlyList<Post>> GetAllPostByUserIdAsync(Guid userId);
        

        Task<IReadOnlyList<Post>> GetCreatedPostsByTimeAsync(DateTime createdAt);
        Task<Post?> GetPostByTitleAsync(string title);
    }
}

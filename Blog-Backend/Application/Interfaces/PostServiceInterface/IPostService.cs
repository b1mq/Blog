using System;
using System.Collections.Generic;
using System.Text;
using Application.Dtos.Post.AddDtos;
using Domain.Entities;

namespace Application.Interfaces.PostServiceInterface
{
    public interface IPostService
    {
        Task<Result> AddNewPost(AddPostDto postDto,Guid userId);
    }
}

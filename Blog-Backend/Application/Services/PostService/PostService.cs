using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces.PostServiceInterface;
using Domain.Interfaces;
using Domain.Entities;
using Application.Dtos.Post.AddDtos;
namespace Application.Services.PostService
{
    public class PostService:IPostService
    { // минимальная версия... нужно добавить полный функционал
        private readonly ITableWriteRepository _tableWriteRepository;
        private readonly ITableReadRepository _tableReadRepository;
        public PostService(ITableReadRepository tableReadRepository,ITableWriteRepository tableWriteRepository)
        {
            _tableReadRepository = tableReadRepository;
            _tableWriteRepository = tableWriteRepository;
        }
        public async Task<Result>AddNewPost(AddPostDto postDto,Guid userId)
        {
            var newResultPost = Post.Create(userId,postDto.title,postDto.content );
            if(newResultPost.value != null)
            {
                var post = newResultPost.value;
                await _tableWriteRepository.AddNewPostAsync(post);
                await _tableWriteRepository.SaveChangesAsync();
                return Result.Succes();
            }
            return Result.Failure(newResultPost.Error);

        } 
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Post
    {
        public Guid Id {  get; private set; }
        public Guid UserId { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Content {  get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public User User { get; private set; } = null!;
        protected Post() { }
        private Post(Guid id,Guid userId,string title,string content)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Content = content;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            
         

        }
        public static ResultGeneric<Post> Create(Guid userId,string title,string content)
        {
            if (userId == Guid.Empty)
                return ResultGeneric<Post>.Failure("Are you drunk? User id can not be empty");

            if (string.IsNullOrWhiteSpace(title))
                return ResultGeneric<Post>.Failure("title cannot be empty");
            if (string.IsNullOrWhiteSpace(content))
                return ResultGeneric<Post>.Failure("content can not be empty you bastard");
           
            var res = new Post(Guid.NewGuid(),userId,title,content);
            return ResultGeneric<Post>.Succes(res);
        }
        private void UpdateActivity() => UpdatedAt = DateTime.UtcNow;
        private Result IsValid(string value)
        {

            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure("Value can not be empty");
            }
            return Result.Succes();
        }

        public Result SetContent(string content)
        {
            var validationResult = IsValid(content);
            if (!validationResult.isSucces)
            {
                return validationResult;
            }
            Content = content;
            UpdateActivity();
            return Result.Succes();
        }
        public Result SetTitle(string title)
        {
            var validationResult = IsValid(title);
            if (!validationResult.isSucces)
            {
                return validationResult;
            }
            Title = title;
            UpdateActivity();
            return Result.Succes();
        }
    }
}

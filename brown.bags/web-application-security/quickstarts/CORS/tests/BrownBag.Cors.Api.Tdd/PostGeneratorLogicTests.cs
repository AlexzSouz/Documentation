using BrownBag.Cors.Api.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace BrownBag.Cors.Api.Tdd
{
    public class PostGeneratorLogicTests
    {
        [Fact]
        public void CreatePostList()
        {
            var posts = new List<Post>();

            int i = 0;
            while (i++ < 10)
            {
                posts.Add(new Post
                {
                    Id = i,
                    Name = $"Post {i}",
                    AuthorName = $"User{i + (i * 2)}",
                    Created = DateTime.Now
                });
            }
        }
    }
}

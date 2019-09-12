using System.Collections.Generic;
using AuthDemo.Web.Controllers.Administrator;
using Microsoft.AspNetCore.Mvc;

namespace AuthDemo.Web.Features.Posts
{
    public class PostsController : AdministratorApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            var posts = new List<Post>
            {
                new Post
                {
                    Id = 1, Title = "Lorem ipsum",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod"
                },
                new Post
                {
                    Id = 2, Title = "Lorem ipsum",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod"
                },
                new Post
                {
                    Id = 3, Title = "Lorem ipsum",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod"
                },
                new Post
                {
                    Id = 4, Title = "Lorem ipsum",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod"
                }
            };


            return Ok(posts);
        }
    }

    public class Post
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}

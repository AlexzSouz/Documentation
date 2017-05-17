using BrownBag.Cors.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrownBag.Cors.Api.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private static List<Post> _postInMemoryRepository = new List<Post>();

        static PostController()
        {
            int i = 0;
            while (i++ < 10)
            {
                _postInMemoryRepository.Add(new Post
                {
                    Id = i,
                    Name = $"Post {i}",
                    AuthorName = $"User{i + (i * 2)}",
                    Created = DateTime.Now
                });
            }
        }

        [Route("All")]
        public List<Post> Get()
        {
            foreach(var router in this.RouteData.Routers)
            {
                var virtualPath = router.GetVirtualPath(new VirtualPathContext(this.HttpContext, this.RouteData.Values, this.RouteData.Values));
            }

            return _postInMemoryRepository;
        }

        [HttpGet]
        public Post Get(int id)
        {
            return _postInMemoryRepository.FirstOrDefault(p => p.Id == id);
        }
        
        [HttpPost]
        public string Post(int id)
        {
            return $"Post {id}";
        }
    }
}

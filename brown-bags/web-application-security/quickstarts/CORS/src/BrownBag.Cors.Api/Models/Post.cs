using System;

namespace BrownBag.Cors.Api.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string AuthorName { get; set; }
        
        public DateTime Created { get; set; }
    }
}

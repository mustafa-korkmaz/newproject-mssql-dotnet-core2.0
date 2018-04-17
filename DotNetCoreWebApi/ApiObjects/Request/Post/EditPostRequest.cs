
using System;

namespace WebApi.ApiObjects.Request.Post
{
    public class EditPostRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
    }
}

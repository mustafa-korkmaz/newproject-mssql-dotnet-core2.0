using System;

namespace WebApi.ApiObjects.ViewModels.Values
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BlogId { get; set; }
    }
}

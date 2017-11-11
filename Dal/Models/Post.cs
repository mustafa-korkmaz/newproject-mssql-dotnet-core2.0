using System;
using System.ComponentModel.DataAnnotations;

namespace Dal.Models
{
    public class Post : EntityBase
    {
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Content { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}

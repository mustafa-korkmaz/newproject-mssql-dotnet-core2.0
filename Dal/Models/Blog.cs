using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dal.Models
{
    public class Blog : EntityBase
    {
        [MaxLength(50)]
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

}

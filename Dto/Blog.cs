using System.Collections.Generic;

namespace Dto
{
    public class Blog : DtoBase
    {
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

}

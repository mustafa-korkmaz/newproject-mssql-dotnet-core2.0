using System;

namespace Dto
{
    public class Category : DtoBase
    {
        public string Name { get; set; }

        public string Desc { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

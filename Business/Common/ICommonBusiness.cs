
using Dto;
using System.Collections.Generic;

namespace Business.Common
{
    public interface ICommonBusiness
    {
        IEnumerable<Category> GetCategories(int id);
    }
}

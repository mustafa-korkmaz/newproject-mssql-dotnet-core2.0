
using Dto;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface ICommonBusiness
    {
        IEnumerable<Category> GetCategories(int id);
    }
}

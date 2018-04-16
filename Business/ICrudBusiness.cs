
using Dal.Models;
using Dto;

namespace Business
{
    public interface ICrudBusiness<TEntity, TDto>
       where TEntity : EntityBase
       where TDto : DtoBase
    {
        /// <summary>
        /// creates new entity from given dto
        /// </summary>
        /// <param name="dto"></param>
        void Add(TDto dto);

        /// <summary>
        /// hard deletes the given entity.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// hard deletes entity by given id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}

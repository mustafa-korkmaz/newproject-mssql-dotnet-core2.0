
using Common.Response;
using Dal.Models;
using Dto;
using System.Collections.Generic;

namespace Business
{
    public interface ICrudBusiness<in TEntity, TDto>
       where TEntity : EntityBase
       where TDto : DtoBase
    {
        /// <summary>
        /// creates new entity from given dto
        /// </summary>
        /// <param name="dto"></param>
        void Add(TDto dto);

        /// <summary>
        /// updates given entity and returns affected row count.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>affected row count in db</returns>
        BusinessResponse<int> Edit(TDto dto);

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

        /// <summary>
        /// returns dto object by given id
        /// </summary>
        /// <param name="id"></param>
        BusinessResponse<TDto> Get(int id);

        /// <summary>
        /// returns all dto objects
        /// </summary>
        BusinessResponse<IEnumerable<TDto>> GetAll();
    }
}

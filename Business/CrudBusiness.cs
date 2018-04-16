using System.Reflection;
using AutoMapper;
using Common;
using Common.Response;
using Dal;
using Dal.Models;
using Dto;
using Services.Logging;

namespace Business
{
    /// <summary>
    /// Abstract class for basic create, update, delete operations.
    /// </summary>
    /// <typeparam name="TEntity">TEntity is db entity.</typeparam>
    /// <typeparam name="TDto">TDto is data transfer object.</typeparam>
    public abstract class CrudBusiness<TEntity, TDto> : ICrudBusiness<TEntity, TDto>
        where TEntity : EntityBase
        where TDto : DtoBase
    {
        protected readonly UnitOfWork Uow;
        protected readonly IRepository<TEntity> Repository;
        protected readonly IMapper Mapper;
        protected readonly ILogService LogService;

        protected CrudBusiness(BlogDbContext context, ILogService logService, IMapper mapper)
        {
            Uow = new UnitOfWork(context);
            Repository = Uow.Repository<TEntity>();
            LogService = logService;
            Mapper = mapper;
        }

        public virtual void Add(TDto dto)
        {
            var entity = Mapper.Map<TDto, TEntity>(dto);

            Repository.Insert(entity);

            Uow.Save();

            dto.Id = entity.Id;

            var type = typeof(TEntity);

            //log db record creation as an info
            LogService.LogInfo(LogType.Create, dto, string.Format("'{0}' entity has been created.", type.ToString()));
        }

        public virtual BusinessResponse<int> Edit(TDto dto)
        {
            var businessResp = new BusinessResponse<int>
            {
                ResponseCode = ResponseCode.Fail
            };

            var entity = Repository.GetById(dto.Id);

            if (entity == null)
            {
                businessResp.ResponseMessage = ErrorMessage.RecordNotFound;
                return businessResp;
            }

            var type = typeof(TEntity);

            var entityProperties = type.GetProperties();

            foreach (PropertyInfo entityProperty in entityProperties)
            {
                if (entityProperty.CanWrite)
                {
                    PropertyInfo dtoProperty = typeof(TDto).GetProperty(entityProperty.Name); //POCO obj must have same prop as model

                    var value = dtoProperty.GetValue(dto); //get entity's new value from dto object

                    entityProperty.SetValue(entity, value, null); //set new value
                }
            }

            Repository.Update(entity);

            var affectedRows = Uow.Save();

            //log db record modification as an info
            LogService.LogInfo(LogType.Modify, entity.Id, string.Format("'{0}' entity has been modified.", type.ToString()));

            businessResp.ResponseData = affectedRows;
            businessResp.ResponseCode = ResponseCode.Success;
            return businessResp;
        }

        public virtual void Delete(int id)
        {
            Repository.Delete(id);

            Uow.Save();

            var type = typeof(TEntity);

            //log db record deletion as an info
            LogService.LogInfo(LogType.HardDelete, id, string.Format("'{0}' entity has been deleted.", type.ToString()));
        }

        public virtual void Delete(TEntity entity)
        {
            Repository.Delete(entity);

            Uow.Save();

            var type = typeof(TEntity);

            //log db record deletion as an info
            LogService.LogInfo(LogType.HardDelete, entity, string.Format("'{0}' entity has been deleted.", type.ToString()));
        }

        public virtual BusinessResponse<TDto> Get(int id)
        {
            var businessResp = new BusinessResponse<TDto>
            {
                ResponseCode = ResponseCode.Fail
            };

            var entity = Repository.GetById(id);

            if (entity == null)
            {
                businessResp.ResponseMessage = ErrorMessage.RecordNotFound;
                return businessResp;
            }

            var dto = Mapper.Map<TEntity, TDto>(entity);

            businessResp.ResponseCode = ResponseCode.Success;
            businessResp.ResponseData = dto;

            return businessResp;
        }
    }
}

﻿using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using Common;
using Common.Response;
using Dal;
using Dal.Models;
using Dto;
using Services.Logging;
using System.Linq;
using Dal.Repositories;

namespace Business
{
    /// <summary>
    /// Abstract class for basic create, update, delete and get operations.
    /// </summary>
    /// <typeparam name="TEntity">TEntity is db entity.</typeparam>
    /// <typeparam name="TDto">TDto is data transfer object.</typeparam>
    /// <typeparam name="TRepository"></typeparam>
    public abstract class CrudBusiness<TRepository, TEntity, TDto> : ICrudBusiness<TEntity, TDto>
        where TEntity : EntityBase
        where TDto : DtoBase
        where TRepository : IRepository<TEntity>
    {
        protected readonly UnitOfWork Uow;
        public TRepository Repository;
        protected readonly IMapper Mapper;
        protected readonly ILogService LogService;

        protected CrudBusiness(BlogDbContext context, ILogService logService, IMapper mapper)
        {
            Uow = new UnitOfWork(context);
            Repository = Uow.Repository<TRepository, TEntity>();
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
                //Only modify settable properties. Do not change CreatedAt property.
                if (entityProperty.CanWrite && entityProperty.Name != "CreatedAt")
                {
                    PropertyInfo dtoProperty = typeof(TDto).GetProperty(entityProperty.Name); //POCO obj must have same prop as model

                    var value = dtoProperty.GetValue(dto); //get new value of entity from dto object

                    entityProperty.SetValue(entity, value, null); //set new value of entity
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

        public virtual BusinessResponse<IEnumerable<TDto>> GetAll()
        {
            var businessResp = new BusinessResponse<IEnumerable<TDto>>
            {
                ResponseCode = ResponseCode.Fail
            };

            var entities = Repository.GetAll();

            if (!entities.Any())
            {
                businessResp.ResponseMessage = ErrorMessage.RecordNotFound;
                return businessResp;
            }

            var dtos = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entities);

            businessResp.ResponseCode = ResponseCode.Success;
            businessResp.ResponseData = dtos;

            return businessResp;
        }
    }
}

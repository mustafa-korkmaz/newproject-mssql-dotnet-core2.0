using AutoMapper;
using Common;
using Dal;
using Dal.Models;
using Dto;
using Services.Logging;

namespace Business
{
    /// <summary>
    /// Abstract class for basic create, update, delete operations.
    /// </summary>
    /// <typeparam name="T">T is db entity</typeparam>
    public abstract class CrudBusiness<TEntity, TDto> : ICrudBusiness<TEntity, TDto>
        where TEntity : EntityBase
        where TDto : DtoBase
    {
        protected readonly UnitOfWork _uow;
        protected readonly IRepository<TEntity> _userRepository;
        protected readonly IMapper _mapper;
        protected readonly ILogService _logService;

        public CrudBusiness(BlogDbContext context, ILogService logService, IMapper mapper)
        {
            _uow = new UnitOfWork(context);
            _userRepository = _uow.Repository<TEntity>();
            _logService = logService;
            _mapper = mapper;
        }
        public virtual void Add(TDto dto)
        {
            var entity = _mapper.Map<TDto, TEntity>(dto);

            _userRepository.Insert(entity);

            _uow.Save();

            dto.Id = entity.Id;

            var type = typeof(TEntity);
            
            //log db record creation as an info
            _logService.LogInfo(LogType.Create, dto, string.Format("'{0}' entity has been created.", type.ToString()));
        }

        public virtual void Delete(int id)
        {
            _userRepository.Delete(id);

            _uow.Save();

            var type = typeof(TEntity);

            //log db record deletion as an info
            _logService.LogInfo(LogType.HardDelete, id, string.Format("'{0}' entity has been deleted.", type.ToString()));
        }

        public virtual void Delete(TEntity entity)
        {
            _userRepository.Delete(entity);

            _uow.Save();

            var type = typeof(TEntity);

            //log db record deletion as an info
            _logService.LogInfo(LogType.HardDelete, entity, string.Format("'{0}' entity has been deleted.", type.ToString()));
        }

        //void Edit(DtoBase dto);

        //void Delete(int id);

        //BusinessResponse<T> Get<T>(int id) where T : DtoBase;
    }
}

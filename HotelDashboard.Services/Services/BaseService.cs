using AutoMapper;
using HotelDashboard.Data.Models;
using HotelDashboard.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelDashboard.Services.Services
{
    /// <summary>
    /// Базовая реализация сервиса
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности, с которой работает сервис</typeparam>
    public class BaseService<TEntity> : IBaseCRUDService<TEntity> where TEntity : BaseModel
    {
        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            repository = this.unitOfWork.GetRepository<TEntity>();
        }

        public virtual async Task<int> AddAsync<TDtoEntity>(TDtoEntity entity)
        {
            TEntity domainEntity = mapper.Map<TEntity>(entity);
            repository.Insert(domainEntity);
            await unitOfWork.SaveAsync();
            return domainEntity.Id;
        }

        public virtual async Task DeleteAsync(int id)
        {
            TEntity item = await repository.GetByIdAsync(id);
            repository.Delete(item);
            await unitOfWork.SaveAsync();
        }

        public virtual async Task<IEnumerable<TDtoEntity>> GetAllAsync<TDtoEntity>()
        {
            var items = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<TDtoEntity>>(items);
        }

        public virtual async Task<TDtoEntity> GetByIdAsync<TDtoEntity>(int id)
        {
            TEntity item = await repository.GetByIdAsync(id);
            return mapper.Map<TDtoEntity>(item);
        }

        public async Task UpdateAsync<TDtoEntity>(TDtoEntity entity)
        {
            TEntity item = mapper.Map<TEntity>(entity);
            repository.Update(item);
            await unitOfWork.SaveAsync();
        }


        protected IUnitOfWork unitOfWork { set; get; }
        protected ICRUDRepository<TEntity> repository { set; get; }
        protected IMapper mapper { set; get; }
    }
}

using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWorks _unitOfWorks;

        public Service(IGenericRepository<T> repository, IUnitOfWorks unitOfWorks)
        {
            _repository = repository;
            _unitOfWorks = unitOfWorks;
        }

        public async Task AddAsync(T entity)
        {
            entity.CreatedTime = DateTime.Now;
            entity.UpdatedTime = DateTime.Now;
            await _repository.AddAsync(entity);
            await _unitOfWorks.CommitAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public void ChangesStatus(T entity)
        {
            entity.UpdatedTime =DateTime.Now;
            _repository.ChangesStatus(entity);
            _unitOfWorks.Commit();
        }

        public int Count()
        {
            return _repository.Count();
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await _repository.GetByIDAsync(id);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWorks.Commit();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}

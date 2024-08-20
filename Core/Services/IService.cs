﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IService<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIDAsync(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        int Count();
        void Update(T entity);
        void ChangesStatus(T entity);
        Task AddAsync(T entity);

    }
}

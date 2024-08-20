using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }


        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await dbSet.AnyAsync(expression);
        }

        public void ChangesStatus(T entity)
        {
            dbSet.Update(entity);
        }

        public int Count()
        {
            return dbSet.Count();
        }

        public IQueryable<T> GetAll()
        {
            return dbSet.Where(x => x.Status==true).AsQueryable();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where<T>(expression);
        }
    }
}

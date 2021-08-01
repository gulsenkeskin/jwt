using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proje.Core.Repositories;

namespace Proje.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        
        protected readonly DbContext _context;

        private readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        //-----ARABİRİMİ UYGULA----//

        public async Task AddAsync(TEntity entity)
        {
          await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public void Remove(TEntity entity)
        {
           _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
           _dbSet.RemoveRange(entities);
        }

        //Parametre olarak eldığı değere göre getir
        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
           _context.Entry(entity).State=EntityState.Modified;
           return entity;
        }

//--------------------------------------------
        //  public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        // {
        //     return await _context.Set<TEntity>().SingleOrDefaultAsync(match);
        // }

        // public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        // {
        //     return await _context.Set<TEntity>().Where(match).ToListAsync();
        // }
    
    }
}
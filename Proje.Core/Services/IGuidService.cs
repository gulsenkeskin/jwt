using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proje.Core.Services
{
    public interface IGuidService<TEntity> where TEntity:class
    {
         //id ye göre ürün çekme
         Task<TEntity> GetByIdAsync(Guid Id);
         //tümünü getir
         Task<IEnumerable<TEntity>> GetAllAsync();

         //id ye göre bul
         Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity,bool>> predicate);

        //parametre olarak gelen değere göre arama yap
         Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity,bool>> predicate);

        //bir nesnenin eklenmesi
        Task<TEntity> AddAsync(TEntity entity);

        //toplu ekleme
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        //silme

        void Remove(TEntity entity);

        //birden fazla silme

        void RemoveRange(IEnumerable<TEntity> entities);

        //güncelleme
        TEntity Update(TEntity entity);

    }
}
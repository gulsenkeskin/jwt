using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proje.Core.Repositories
{

    public interface IRepository<TEntity> where TEntity:class
    {
        //id ye göre ürün çekme
         Task<TEntity> GetByIdAsync(int Id);
         //tümünü getir
         Task<IEnumerable<TEntity>> GetAllAsync();

         //id ye göre bul
         Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity,bool>>predicate);

        //parametre olarak gelen değere göre arama yap //1 tane döner ilk bulduğunu döner
         Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity,bool>> predicate);

        //bir nesnenin eklenmesi
        Task AddAsync(TEntity entity);

        //toplu ekleme
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        //silme

        void Remove(TEntity entity);

        //birden fazla silme

        void RemoveRange(IEnumerable<TEntity> entities);

        //güncelleme
        TEntity Update(TEntity entity);


        //--------------------------------------
        // Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);
        
        // Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);





    }
}
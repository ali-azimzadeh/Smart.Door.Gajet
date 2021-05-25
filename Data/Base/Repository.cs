using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public class Repository<T> : object, IRepository<T> where T : Models.Base.Entity
    {
        internal Repository(DatabaseContext databaseContext)
        {
            DatabaseContext =
                databaseContext ?? throw new System.ArgumentNullException(paramName: nameof(databaseContext));

            DbSet = DatabaseContext.Set<T>();
        }

        // **********
        internal DatabaseContext DatabaseContext { get; }
        // **********

        // **********
        internal Microsoft.EntityFrameworkCore.DbSet<T> DbSet { get; }
        // **********

        public virtual void Insert(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            DbSet.Add(entity);
        }

        public virtual async System.Threading.Tasks.Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            await DbSet.AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }
            
            DbSet.Update(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }
            await System.Threading.Tasks.Task.Run(() =>
            {
                DbSet.Update(entity);
            });
        }

        public virtual IList<T> GetAll()
        {
            var result =
             DbSet.ToList()
             ;

            return result;
        }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            var result =
               await
               DbSet.ToListAsync()
               ;

            return result;
        }

        public virtual T GetById(Guid id)
        {
            //var result =
            //     DbSet.Where(current => current.Id == id)
            //     .FirstOrDefault()
            //     ;

            var result =
              DbSet.Find(keyValues: id)
              ;

            return result;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            var result =
                await
                  DbSet.FindAsync(keyValues: id )
                  ;

            return result;
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            DbSet.Remove(entity);
        }

        public virtual async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            await System.Threading.Tasks.Task.Run(() =>
            {
                DbSet.Remove(entity);
            });
        }

        public virtual bool DeleteById(Guid id)
        {
            T entity =  GetById(id);

            if (entity == null)
            {
                return false;
            }

            Delete(entity);

            return true;
        }

        public virtual async System.Threading.Tasks.Task<bool> DeleteByIdAsync(System.Guid id)
        {
            T entity =
                await GetByIdAsync(id);

            if (entity == null)
            {
                return false;
            }

            await DeleteAsync(entity);

            return true;
        }

    }
}

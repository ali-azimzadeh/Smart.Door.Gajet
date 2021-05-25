using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public interface IRepository<T> where T : Models.Base.Entity
    {
        void Insert(T entity);

        Task InsertAsync(T entity);

        void Update(T entity);

        Task UpdateAsync(T entity);

        void Delete(T entity);

        Task DeleteAsync(T entity);

        T GetById(System.Guid id);

        Task<T> GetByIdAsync(System.Guid id);

        bool DeleteById(System.Guid id);
        
        Task<bool> DeleteByIdAsync(System.Guid id);

        IList<T> GetAll();

        Task<IList<T>> GetAllAsync();
    }
}

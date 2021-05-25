using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Repository<T> : Base.Repository<T> where T : Models.Base.Entity
    {
        internal Repository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override void Insert(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            entity.InsertDateTime = Models.Utility.Now;
            entity.IsDeleted = false;

            DbSet.Add(entity);
        }

        public override async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            entity.InsertDateTime = Models.Utility.Now;
            entity.IsDeleted = false;

            await DbSet.AddAsync(entity);
        }
    }
}

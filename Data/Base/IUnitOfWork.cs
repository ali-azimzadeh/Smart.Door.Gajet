using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public interface IUnitOfWork : System.IDisposable
    {
        bool IsDisposed { get; }

        void Save();

        System.Threading.Tasks.Task SaveAsync();

        Repository<T> GetRepository<T>() where T : Models.Base.Entity;
    }
}

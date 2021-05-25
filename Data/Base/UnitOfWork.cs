using Microsoft.EntityFrameworkCore;
using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public class UnitOfWork : object, IUnitOfWork
    {
        public UnitOfWork(Tools.Options options) : base()
        {
            Options = options;
        }

        protected Tools.Options Options { get; set; }

        private DatabaseContext _databaseContext;
        private bool disposedValue;

        public DatabaseContext DatabaseContext
        {
            get
            {
                if (_databaseContext == null)
                {
                    var optionsBuilder =
                        new DbContextOptionsBuilder<DatabaseContext>();

                    switch (Options.Provider)
                    {
                        case Tools.Enums.Provider.SqlServer:
                            {
                                optionsBuilder.UseSqlServer
                                    (connectionString: Options.ConnectionString);
                                break;
                            }
                        case Tools.Enums.Provider.MySql:
                            {
                                //optionsBuilder.UseMySql
                                //	(connectionString: Options.ConnectionString);

                                break;
                            }

                        case Tools.Enums.Provider.Oracle:
                            {
                                //optionsBuilder.UseOracle
                                //	(connectionString: Options.ConnectionString);

                                break;
                            }

                        case Tools.Enums.Provider.PostgreSQL:
                            {
                                //optionsBuilder.UsePostgreSQL
                                //	(connectionString: Options.ConnectionString);

                                break;
                            }

                        case Tools.Enums.Provider.InMemory:
                            {
                                //      optionsBuilder.UseInMemoryDatabase(databaseName: "Temp");

                                break;
                            }

                        default:
                            {
                                break;
                            }
                    }
                    _databaseContext = new DatabaseContext(options: optionsBuilder.Options);
                }
                return _databaseContext;
            }
        }

        public bool IsDisposed { get; protected set; }

        public virtual void Save()
        {
           
            DatabaseContext.SaveChanges();
        }

        public virtual async Task SaveAsync()
        {
            await DatabaseContext.SaveChangesAsync();
        }

        public Repository<T> GetRepository<T>() where T : Entity
        {
            return new Repository<T>(databaseContext: DatabaseContext);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed == true)
            {
                return;
            }

            if (disposing == true)
            {
                if (_databaseContext != null)
                {
                    _databaseContext.Dispose();
                    _databaseContext = null;
                }
            }
            //if (!disposedValue)
            //{
            //    if (disposing)
            //    {
            //        // TODO: dispose managed state (managed objects)
            //    }

            //    // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            //    // TODO: set large fields to null
            //    disposedValue = true;
            //}
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~UnitOfWork()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

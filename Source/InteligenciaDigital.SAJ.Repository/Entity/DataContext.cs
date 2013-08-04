using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Threading;
using InteligenciaDigital.SAJ.Domain.Entidades;
using InteligenciaDigital.SAJ.Domain.Interfaces;
using System.Text;

namespace InteligenciaDigital.SAJ.Repository.Entity
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext()
            : this(true)
        {
        }

        public DataContext(bool proxyCreation = true)
        {
            this.Configuration.ProxyCreationEnabled = proxyCreation;

            //[DropAndReCreate if in debug and model is changed. ONLY FOR DEVELOPMENT!!!]
            //if (System.Diagnostics.Debugger.IsAttached)
            //    Database.SetInitializer(new DataSeeder());
        }

        public ObjectContext ObjectContext()
        {
            return ((IObjectContextAdapter)this).ObjectContext;
        }

        public virtual IDbSet<T> DbSet<T>() where T : PersistentEntity
        {
            return Set<T>();
        }

        public new DbEntityEntry Entry<T>(T entity) where T : PersistentEntity
        {
            return base.Entry(entity);
        }

        public DbSet<ServidorTEF> ServidoresTef { get; set; }
    }


    public class DataSeeder : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            
        }

        
    }

}

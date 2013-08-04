using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using InteligenciaDigital.SAJ.Domain.Entidades;

namespace InteligenciaDigital.SAJ.Domain.Interfaces
{
    public interface IDataContext
    {
        ObjectContext ObjectContext();

        IDbSet<T> DbSet<T>() where T : PersistentEntity;

        DbEntityEntry Entry<T>(T entity) where T : PersistentEntity;

        void Dispose();
    }
}

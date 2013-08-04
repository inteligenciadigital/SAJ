using System.Collections.Generic;
using System.Data;
using System.Linq;
using InteligenciaDigital.SAJ.Domain.Entidades;
using InteligenciaDigital.SAJ.Domain.Interfaces;

namespace InteligenciaDigital.SAJ.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private IDataContext _datacontext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            DataContext.ObjectContext().SavingChanges += (sender, e) => BeforeSave(GetChangedOrNewEntities());
        }

        public IDataContext DataContext
        {
            get { return _datacontext ?? (_datacontext = _databaseFactory.Get()); }
        }

        public int Commit()
        {
            return DataContext.ObjectContext().SaveChanges();
        }

        /// <summary>
        ///     Extracts new or changed entities and return them as PersistenEntities.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<PersistentEntity> GetChangedOrNewEntities()
        {
            const EntityState newOrModified = EntityState.Added | EntityState.Modified;

            return DataContext.ObjectContext().ObjectStateManager.GetObjectStateEntries(newOrModified)
                              .Where(x => x.Entity != null).Select(x => x.Entity as PersistentEntity);
        }

        /// <summary>
        ///     Before save, we will set the updated and created time.
        ///     We do this in save or update, but here we can reach all children that may have been edited/created.
        ///     In saveOrUpdate it´s only the current entity getting accessed...
        /// </summary>
        /// <param name="entities"></param>
        public void BeforeSave(IEnumerable<PersistentEntity> entities)
        {
        }

        public static bool IsPersistent(PersistentEntity entity)
        {
            return entity.Id != 0;
        }
    }
}
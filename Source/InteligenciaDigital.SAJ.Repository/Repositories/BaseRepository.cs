using System;
using System.Data.Entity;
using System.Linq;
using InteligenciaDigital.SAJ.Domain.Entidades;
using InteligenciaDigital.SAJ.Domain.Interfaces;
using System.Data;

namespace InteligenciaDigital.SAJ.Repository.Repositories
{
    /// <summary>
    /// An abstract baseclass handling basic CRUD operations against the context.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRepository<T> : IDisposable, IRepository<T> where T : PersistentEntity
    {
        private IDataContext _context;
        private readonly IDbSet<T> _dbset;
        private readonly IDatabaseFactory _databaseFactory;

        protected BaseRepository(IDatabaseFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
            this._dbset = this.DataContext.DbSet<T>();
        }

        public IDataContext DataContext
        {
            get { return this._context ?? (this._context = this._databaseFactory.Get()); }
        }

        /// <summary>
        /// The name of the Generic entity using the repository.
        /// Used for smoother queries.
        /// </summary>
        protected string EntitySetName { get; set; }

        /// <summary>
        /// Saves a new entity of T or updates an in the context existing entity (if it´s changed).
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual void SaveOrUpdate(T entity)
        {
            if (UnitOfWork.IsPersistent(entity))
            {
                this.DataContext.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                this._dbset.Add(entity);
            }
        }

        /// <summary>
        /// Get one entity of T
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(long id)
        {
            return this._dbset.Find(id);
        }

        /// <summary>
        /// Get all entities of T
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll()
        {
            return this._dbset;
        }

        /// <summary>
        /// Get all entities of T without tracking
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAllReadOnly()
        {
            return this._dbset.AsNoTracking();
        }

        /// <summary>
        /// Removes an entity T from the context and persist the change.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            this._dbset.Remove(entity);
        }

        public void Dispose()
        {
            this.DataContext.ObjectContext().Dispose();
        }
    }
}

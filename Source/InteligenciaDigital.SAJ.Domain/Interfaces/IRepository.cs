using System.Linq;

namespace InteligenciaDigital.SAJ.Domain.Interfaces
{
    /// <summary>
    /// The generic base interface for all repositories...
    /// Purpose:
    /// - Implement this on the repository... Regardless of datasource... Xml, MSSQL, MYSQL etc..
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Returns all persistent entities of type T.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Return all persistent entities of type T without tracking.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAllReadOnly();

        /// <summary>
        /// Retrieves an entity (T) from the repository by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(long id);

        /// <summary>
        /// Adds a new entity (T) and returns it´s id.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void SaveOrUpdate(T entity);

        /// <summary>
        /// Remove an entity (T) and persist changes into repository.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}


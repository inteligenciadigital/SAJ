using System.Linq;
using System.ServiceModel;
using FluentValidation.Results;

namespace InteligenciaDigital.SAJ.Service.Interfaces
{
    /// <summary>
    ///     Generic base interface for all services.
    ///     Purpose:
    ///     - Implement BusinessLogic in services
    ///     - Hide IRepository from being exposed further out than service layer.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ServiceContract]
    public interface IService<T>
    {
        [OperationContract]
        IQueryable<T> GetAll();

        [OperationContract]
        IQueryable<T> GetAllReadOnly();

        [OperationContract]
        T GetById(long id);

        [OperationContract]
        ValidationResult SaveOrUpdate(T entity);

        [OperationContract]
        void Delete(T entity);
    }
}
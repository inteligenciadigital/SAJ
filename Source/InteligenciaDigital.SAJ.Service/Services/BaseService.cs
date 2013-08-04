using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using InteligenciaDigital.SAJ.Domain.Entidades;
using InteligenciaDigital.SAJ.Domain.Interfaces;
using InteligenciaDigital.SAJ.Domain.Validations;
using InteligenciaDigital.SAJ.Service.Interfaces;

namespace InteligenciaDigital.SAJ.Service.Services
{
    /// <summary>
    ///     Base for all services... If you need specific businesslogic
    ///     override these methods in inherited classes and implement the logic there.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseService<T> : IService<T> where T : PersistentEntity
    {
        protected IRepository<T> Repository;

        protected IUnitOfWork UnitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual IQueryable<T> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual IQueryable<T> GetAllReadOnly()
        {
            return Repository.GetAllReadOnly();
        }

        public virtual T GetById(long id)
        {
            return Repository.GetAll().Where(x => x.Id == id).SingleOrDefault();
        }

        public virtual ValidationResult SaveOrUpdate(T entity)
        {
            var validator = (AbstractValidator<T>) CreateValidator();
            var result = validator.Validate(entity);

            if (result.IsValid)
            {
                Repository.SaveOrUpdate(entity);
                UnitOfWork.Commit();
            }
            
            return result;
        }

        public virtual void Delete(T entity)
        {
            Repository.Delete(entity);
            UnitOfWork.Commit();
        }

        private object CreateValidator()
        {
            if (typeof(T) == typeof(ServidorTEF))
            {
                return new ServidorTEFValidator();
            }

            return null;
        }
    }
}
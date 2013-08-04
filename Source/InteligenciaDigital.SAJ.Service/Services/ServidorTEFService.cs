using InteligenciaDigital.SAJ.Domain.Entidades;
using InteligenciaDigital.SAJ.Domain.Interfaces;
using InteligenciaDigital.SAJ.Repository.Interfaces;

namespace InteligenciaDigital.SAJ.Service.Services
{
    public class ServidorTEFService : BaseService<ServidorTEF>, IServidorTEFService
    {
        public ServidorTEFService(IServidorTEFRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Repository = repository;
        }
    }
}

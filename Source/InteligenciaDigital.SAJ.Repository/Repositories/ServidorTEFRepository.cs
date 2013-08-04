using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteligenciaDigital.SAJ.Domain.Entidades;
using InteligenciaDigital.SAJ.Domain.Interfaces;
using InteligenciaDigital.SAJ.Repository.Entity;
using InteligenciaDigital.SAJ.Repository.Interfaces;

namespace InteligenciaDigital.SAJ.Repository.Repositories
{
    public class ServidorTEFRepository : BaseRepository<ServidorTEF>, IServidorTEFRepository
    {
        public ServidorTEFRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}

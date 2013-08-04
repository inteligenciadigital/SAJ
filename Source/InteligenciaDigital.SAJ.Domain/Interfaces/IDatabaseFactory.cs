using System;

namespace InteligenciaDigital.SAJ.Domain.Interfaces
{
    public interface IDatabaseFactory : IDisposable
    {
        IDataContext Get();
    }
}

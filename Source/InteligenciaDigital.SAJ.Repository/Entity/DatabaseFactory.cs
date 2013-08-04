using InteligenciaDigital.SAJ.Domain.Interfaces;

namespace InteligenciaDigital.SAJ.Repository.Entity
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private IDataContext _datacontext;

        public IDataContext Get()
        {
            return _datacontext ?? (_datacontext = new DataContext());
        }

        public void Dispose()
        {
            //TODO: Check what ninjetc does, because if we dispose this it will crash!
        }
    }
}

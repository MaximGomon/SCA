using System;

namespace SCA.DataAccess
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private ScaDbContext dataContext;
        public ScaDbContext Get()
        {
            return dataContext ?? (dataContext = new ScaDbContext());
        }
        public void Dispose()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
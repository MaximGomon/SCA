using System;

namespace SCA.DataAccess
{
    public interface IDatabaseFactory : IDisposable
    {
        ScaDbContext Get();
    }
}
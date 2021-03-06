﻿using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class ClientSitePageRepository : CrudRepository<ClientSitePage>, IClientSitePageRepository
    {
        public ClientSitePageRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            
        }
    }
}
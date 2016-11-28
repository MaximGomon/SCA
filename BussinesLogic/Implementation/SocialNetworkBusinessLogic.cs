using System;
using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class SocialNetworkBusinessLogic : BaseBusinessLogic<ISocialNetworkRepository, SocialNetworkEvent>, ISocialNetworkBusinessLogic
    {
        public SocialNetworkBusinessLogic(ISocialNetworkRepository repository) : base(repository)
        {
        }

        public SocialNetworkEvent GetEventByEventId(string eventId)
        {
            return Repository.GetAllEntities().FirstOrDefault(x => x.EventId == eventId);
        }
    }
}
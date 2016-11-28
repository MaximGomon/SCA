using SCA.Domain;

namespace SCA.BussinesLogic
{
    public interface ISocialNetworkBusinessLogic : IBaseBusinessLogic<SocialNetworkEvent>
    {
        SocialNetworkEvent GetEventByEventId(string eventId);
    }
}
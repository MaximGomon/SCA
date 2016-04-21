using System.Runtime.Serialization;

namespace SCA.Models.Facebook
{
    [DataContract]
    public class FbData
    {
        [DataMember]
        public FbFeeds feed;
    }
}
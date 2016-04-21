using System.Runtime.Serialization;

namespace SCA.Models.Facebook
{
    [DataContract]
    public class FbFeeds
    {
        [DataMember]
        public FbFeed[] data;
    }
}
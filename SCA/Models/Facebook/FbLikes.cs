using System.Runtime.Serialization;

namespace SCA.Models.Facebook
{
    [DataContract]
    public class FbLikes
    {
        [DataMember]
        public FbLike[] data;
    }
}
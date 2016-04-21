using System.Runtime.Serialization;

namespace SCA.Models.Facebook
{
    [DataContract]
    public class FbLike
    {
        [DataMember]
        public string id;
        [DataMember]
        public string name;
        [DataMember]
        public string link;
    }
}
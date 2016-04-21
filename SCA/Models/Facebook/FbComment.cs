using System.Runtime.Serialization;

namespace SCA.Models.Facebook
{
    [DataContract]
    public class FbComment
    {
        [DataMember]
        public string id;
        [DataMember]
        public string message;
        [DataMember]
        public FbFrom from;
    }
}
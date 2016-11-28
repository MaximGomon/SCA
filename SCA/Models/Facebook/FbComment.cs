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
        [DataMember(Name = "created_time")]
        public string CreateTime;
        [DataMember]
        public FbFrom from;
    }
}
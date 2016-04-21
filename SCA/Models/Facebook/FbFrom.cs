using System.Runtime.Serialization;

namespace SCA.Models.Facebook
{
    [DataContract]
    public class FbFrom
    {
        [DataMember]
        public string name;
        [DataMember]
        public string id;
    }
}
using System.Runtime.Serialization;

namespace SCA.Models.Facebook
{
    [DataContract]
    public class FbComments
    {
        [DataMember]
        public FbComment[] data;
    }
}
using System;
using System.Runtime.Serialization;

namespace SCA.Models.Facebook
{
    [DataContract]
    public class FbFeed
    {
        [DataMember]
        public string link;
        [DataMember]
        public FbFrom from;
        [DataMember]
        public string type;
        [DataMember]
        public string id;
        [DataMember]
        public string updated_time;
        [DataMember]
        public string created_time;
        [DataMember]
        public FbLikes likes;
        [DataMember]
        public FbComments comments;
        [DataMember]
        public string message;
    }
}
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace SCA.CountersService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICounterService" in both code and config file together.
    
    [ServiceContract]
    public interface ICounterService
    {
        [WebInvoke]
        [OperationContract]
        void DoWork(CounterData data);
    }

    [DataContract]
    public class CounterData
    {
        [DataMember]
        public string Ip { get; set; }
        [DataMember]
        public string Tags { get; set; }
        [DataMember]
        public string Cookie { get; set; }
        [DataMember]
        public string Agent { get; set; }
    }
}

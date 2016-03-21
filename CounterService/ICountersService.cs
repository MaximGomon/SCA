using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CounterService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICountersService" in both code and config file together.
    [ServiceContract]
    public interface ICountersService
    {
        [OperationContract]
        string GetData(int value);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "CounterService.ContractType".
    [DataContract]
    public class CounterData
    {
        [DataMember]
        public bool Ip { get; set; }
        
    }
}

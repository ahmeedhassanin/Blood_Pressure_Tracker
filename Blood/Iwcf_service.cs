using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Blood
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_service" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_service
    {
        [OperationContract(IsOneWay =false)]
        UserClass ViewProfile(string email);
        [OperationContract(IsOneWay = true)]
        void Register(string name, int age, int weight, string gender, string email, string password);

    }
}
